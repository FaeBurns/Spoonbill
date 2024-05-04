using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Spoonbill.Wpf.Data;

namespace Spoonbill.Wpf;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public App()
    {
        IHostBuilder host = Host.CreateDefaultBuilder().ConfigureServices(ConfigureServices);

        host.Build();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<App>();
        services.AddDbContext<SpoonbillContext>();
    }
}