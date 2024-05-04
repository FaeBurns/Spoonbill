using System.Net;
using System.Net.Sockets;
using Docker.DotNet;
using Docker.DotNet.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data;

namespace Spoonbill.Tests;

[SetUpFixture]
public class TestSetup
{
    private readonly TestDatabase m_testDatabase = new TestDatabase();

    [OneTimeSetUp]
    public async Task Setup()
    {
        ConnectionString = await m_testDatabase.Setup();
    }

    [OneTimeTearDown]
    public async Task Teardown()
    {
        await m_testDatabase.Teardown();
    }

    public static string ConnectionString { get; private set; } = null!;

    public static DbContextOptions<SpoonbillContext> Options =>
        new DbContextOptionsBuilder<SpoonbillContext>()
            .UseSqlServer(ConnectionString)
            .EnableSensitiveDataLogging()
            .Options;
}

internal class TestDatabase
{
    // https://wrapt.dev/blog/integration-tests-using-sql-server-db-in-docker
    private const string DB_PASSWORD = "S3cureDb$Password";
    private const string DB_USER = "SA";
    private const string DB_IMAGE = "mcr.microsoft.com/mssql/server";
    private const string DB_IMAGE_TAG = "2019-latest";
    private const string DB_CONTAINER_NAME = "SpoonbillTestingContainer";
    private const string DB_VOLUME_NAME = "SpoonbillTestingVolume";

    private IDockerClient m_dockerClient = null!;

    public async Task<string> Setup()
    {
        m_dockerClient = GetDockerClient();

        try
        {
            await m_dockerClient.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
        }
        catch (TimeoutException)
        {
            throw new InconclusiveException("Docker must be started before tests can run.");
        }

        (string _, string port) = await EnsureDockerStartedAndGetContainerIdAndPortAsync();

        return GetConnectionString(port);
    }

    public async Task Teardown()
    {
        IList<ContainerListResponse> containers = await m_dockerClient.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
        ContainerListResponse? existingContainer = containers.FirstOrDefault(c => c.Names.Any(n => n.Contains(DB_CONTAINER_NAME)));

        // if (existingContainer != null)
        //     await m_dockerClient.Containers.StopContainerAsync(existingContainer.ID, new ContainerStopParameters());
        // else
        //     Console.WriteLine("No container was running to stop during teardown");

        // no teardown required
        await Task.CompletedTask;
    }

    private async Task<(string containerId, string port)> EnsureDockerStartedAndGetContainerIdAndPortAsync()
    {
        await CleanupRunningContainers();
        await CleanupRunningVolumes();
        string freePort = GetFreePort();

        Progress<JSONMessage> progress = new Progress<JSONMessage>(m => TestContext.WriteLine(m.ProgressMessage));
        // ensure that the latest image exists
        await m_dockerClient.Images.CreateImageAsync(new ImagesCreateParameters()
        {
            FromImage = $"{DB_IMAGE}:{DB_IMAGE_TAG}",
        }, null, progress);

        // create volume if it's missing
        VolumesListResponse volumes = await m_dockerClient.Volumes.ListAsync();
        int volumeCount = volumes.Volumes.Count(v => v.Name == DB_VOLUME_NAME);
        if (volumeCount < 0)
        {
            await m_dockerClient.Volumes.CreateAsync(new VolumesCreateParameters()
            {
                Name = DB_VOLUME_NAME,
            });
        }

        IList<ContainerListResponse> containers = await m_dockerClient.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
        ContainerListResponse? existingContainer = containers.FirstOrDefault(c => c.Names.Any(n => n.Contains(DB_CONTAINER_NAME)));

        if (existingContainer == null)
        {
            CreateContainerResponse container = await m_dockerClient.Containers.CreateContainerAsync(new CreateContainerParameters()
            {
                Name = DB_CONTAINER_NAME,
                Image = $"{DB_IMAGE}:{DB_IMAGE_TAG}",
                Env = new List<string>()
                {
                    "ACCEPT_EULA=Y",
                    $"SA_PASSWORD={DB_PASSWORD}",
                    "MSSQL_PID=Enterprise",
                },
                HostConfig = new HostConfig()
                {
                    PortBindings = new Dictionary<string, IList<PortBinding>>
                    {
                        {
                            "1433/tcp",
                            new[]
                            {
                                new PortBinding()
                                {
                                    HostPort = freePort,
                                },
                            }
                        },
                    },
                    Binds = new List<string>
                    {
                        $"{DB_VOLUME_NAME}:/Accessioning_data",
                    },
                },
            });

            await m_dockerClient.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());
            await WaitUntilDatabaseAvailableAsync(freePort);
            return (container.ID, freePort);
        }

        await m_dockerClient.Containers.StartContainerAsync(existingContainer.ID, new ContainerStartParameters());

        // re-get container
        // this one will have port information
        containers = await m_dockerClient.Containers.ListContainersAsync(new ContainersListParameters() { All = true });
        existingContainer = containers.First(c => c.Names.Any(n => n.Contains(DB_CONTAINER_NAME)));
        await WaitUntilDatabaseAvailableAsync(existingContainer.Ports.First().PublicPort.ToString());

        return (existingContainer.ID, existingContainer.Ports.First().PublicPort.ToString());
    }

    private async Task WaitUntilDatabaseAvailableAsync(string dbPort)
    {
        DateTime start = DateTime.UtcNow;
        const int maxWaitTimeSeconds = 60;
        bool connectionEstablished = false;

        // while there is no connection and the time is not yet up
        while (!connectionEstablished && start.AddSeconds(maxWaitTimeSeconds) > DateTime.UtcNow)
        {
            try
            {
                string connectionString = GetConnectionString(dbPort);
                await using SqlConnection connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                connectionEstablished = true;
            }
            catch
            {
                TestContext.WriteLine("Failed to connect to database, waiting 500ms and trying again. Exception:");
                await Task.Delay(500);
            }
        }

        if (!connectionEstablished)
            throw new Exception($"Connection to the SQL docker container could not be established within {maxWaitTimeSeconds} seconds.");

        // set up the database
        try
        {
            string connectionString = GetConnectionString(dbPort);
            await using SqlConnection connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            // ReSharper disable once StringLiteralTypo
            string fileContents = await File.ReadAllTextAsync("dbsetup\\database.sql");
            string[] statements = fileContents.Split(';');
            foreach (string statement in statements)
            {
                // create the command from each individual statement
                // the semicolon is removed from split so add it back
                await using SqlCommand cmd = new SqlCommand(statement + ';', connection);
                await cmd.ExecuteNonQueryAsync();
            }
        }
        catch (Exception e)
        {
            TestContext.WriteLine("Exception occured while trying to setup database");
            // TestContext.WriteLine(e);
            throw;
        }

        TestContext.WriteLine("Connection established.");
    }

    private string GetConnectionString(string dbPort)
    {
        return $"Data Source=localhost,{dbPort};" +
               $"Integrated Security=False;" +
               $"Trust Server Certificate=True;" +
               $"User ID={DB_USER};" +
               $"Password={DB_PASSWORD}";
    }

    private IDockerClient GetDockerClient()
    {
        string dockerUrl = "npipe://./pipe/docker_engine";
        return new DockerClientConfiguration(new Uri(dockerUrl)).CreateClient();
    }

    private async Task CleanupRunningContainers(int hoursTillExpiration = -24)
    {
        IList<ContainerListResponse> runningContainers = await m_dockerClient.Containers.ListContainersAsync(new ContainersListParameters());

        foreach (ContainerListResponse container in runningContainers.Where(c => c.Names.Any(n => n.Contains(DB_CONTAINER_NAME))))
        {
            // stop if it's older than hoursTillExpiration hours (default 24)
            int expiration = -Math.Abs(hoursTillExpiration);
            if (container.Created < DateTime.UtcNow.AddHours(expiration))
            {
                try
                {
                    await EnsureDockerContainerStoppedAndRemovedAsync(container.ID);
                }
                catch
                {
                    TestContext.WriteLine($"Failed to stop expired container {container.ID}");
                }
            }
        }
    }

    private async Task EnsureDockerContainerStoppedAndRemovedAsync(string containerId)
    {
        await m_dockerClient.Containers.StopContainerAsync(containerId, new ContainerStopParameters());
        await m_dockerClient.Containers.RemoveContainerAsync(containerId, new ContainerRemoveParameters());
    }

    private async Task CleanupRunningVolumes(int hoursTillExpiration = -24)
    {
        VolumesListResponse volumes = await m_dockerClient.Volumes.ListAsync();

        foreach (VolumeResponse volume in volumes.Volumes.Where(v => v.Name == DB_VOLUME_NAME))
        {
            int expiration = -Math.Abs(hoursTillExpiration);
            if (DateTime.Parse(volume.CreatedAt) < DateTime.UtcNow.AddHours(expiration))
            {
                try
                {
                    await EnsureDockerVolumeRemovedAsync(volume.Name);
                }
                catch
                {
                    TestContext.WriteLine($"Failed to stop expired volume {volume.Name}");
                }
            }
        }
    }

    private async Task EnsureDockerVolumeRemovedAsync(string volumeName)
    {
        await m_dockerClient.Volumes.RemoveAsync(volumeName);
    }

    private string GetFreePort()
    {
        using TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 0);

        tcpListener.Start();
        int port = ((IPEndPoint)tcpListener.LocalEndpoint).Port;
        tcpListener.Stop();

        return port.ToString();
    }
}