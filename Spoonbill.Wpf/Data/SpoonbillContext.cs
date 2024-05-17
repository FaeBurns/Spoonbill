using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Data;

public class SpoonbillContext : DbContext
{
    public SpoonbillContext(DbContextOptions<SpoonbillContext> options) : base(options)
    {
    }

    public DbSet<Passenger> Passengers { get; set; } = null!;
    public DbSet<Pilot> Pilots { get; set; } = null!;
    public DbSet<StaffWorker> StaffWorkers { get; set; } = null!;
    public DbSet<Flight> Flights { get; set; } = null!;
    public DbSet<Plane> Planes { get; set; } = null!;
    public DbSet<PlaneModel> PlaneModels { get; set; } = null!;
    public DbSet<Manufacturer> Manufacturers { get; set; } = null!;
    public DbSet<Airport> Airports { get; set; } = null!;
    public DbSet<City> Cities { get; set; } = null!;
    public DbSet<County> Counties { get; set; } = null!;
    public DbSet<FlightStop> Stops { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasAnnotation("ProductVersion", "8.0.4")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        modelBuilder.UseIdentityColumns();

        modelBuilder.Entity("FlightPassenger", b =>
        {
            b.Property<int>("FlightsFlightId")
                .HasColumnType("int");

            b.Property<int>("PassengersId")
                .HasColumnType("int");

            b.HasKey("FlightsFlightId", "PassengersId");

            b.HasIndex("PassengersId");

            b.ToTable("FlightPassenger");
        });

        modelBuilder.Entity("FlightPilot", b =>
        {
            b.Property<int>("AssignedFlightsFlightId")
                .HasColumnType("int");

            b.Property<int>("PilotsId")
                .HasColumnType("int");

            b.HasKey("AssignedFlightsFlightId", "PilotsId");

            b.HasIndex("PilotsId");

            b.ToTable("FlightPilot");
        });

        modelBuilder.Entity("FlightStaffWorker", b =>
        {
            b.Property<int>("AssignedFlightsFlightId")
                .HasColumnType("int");

            b.Property<int>("WorkerStaffId")
                .HasColumnType("int");

            b.HasKey("AssignedFlightsFlightId", "WorkerStaffId");

            b.HasIndex("WorkerStaffId");

            b.ToTable("FlightStaffWorker");
        });

        modelBuilder.Entity<Airport>(b =>
        {
            b.Property<string>("Name")
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("CityName")
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            b.HasKey("Name");

            b.HasIndex("CityName");

            b.ToTable("Airports");
        });

        modelBuilder.Entity<City>(b =>
        {
            b.Property<string>("Name")
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("CountyName")
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            b.HasKey("Name");

            b.HasIndex("CountyName");

            b.ToTable("Cities");
        });

        modelBuilder.Entity<County>(b =>
        {
            b.Property<string>("Name")
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("Country")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.HasKey("Name");

            b.ToTable("Counties");
        });

        modelBuilder.Entity<Flight>(b =>
        {
            b.Property<int>("FlightId")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            b.Property<int>("FlightId").UseIdentityColumn();

            b.Property<DateTime>("ArrivalTime")
                .HasColumnType("datetime2");

            b.Property<DateTime>("DepartureTime")
                .HasColumnType("datetime2");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("PlaneSerial")
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            b.HasKey("FlightId");

            b.HasIndex("PlaneSerial");

            b.ToTable("Flights");
        });

        modelBuilder.Entity<FlightStop>(b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            b.Property<int>("Id").UseIdentityColumn();

            b.Property<string>("AirportName")
                .IsRequired()
                .HasColumnType("nvarchar(20)");

            b.Property<int?>("FlightId")
                .HasColumnType("int");

            b.Property<int>("Order")
                .HasColumnType("int");

            b.HasKey("Id");

            b.HasIndex("AirportName");

            b.HasIndex("FlightId");

            b.ToTable("Stops");
        });

        modelBuilder.Entity<Manufacturer>(b =>
        {
            b.Property<string>("Name")
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("CityName")
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            b.HasKey("Name");

            b.HasIndex("CityName");

            b.ToTable("Manufacturers");
        });

        modelBuilder.Entity<Passenger>(b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            b.Property<int>("Id").UseIdentityColumn();

            b.Property<string>("Address")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("PhoneNumber")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("Surname")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.HasKey("Id");

            b.ToTable("Passengers");
        });

        modelBuilder.Entity<Pilot>(b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            b.Property<int>("Id").UseIdentityColumn();

            b.Property<string>("Address")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("PhoneNumber")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<decimal>("Salary")
                .HasPrecision(8, 2)
                .HasColumnType("decimal(8,2)");

            b.Property<string>("Surname")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("TypeRating")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.HasKey("Id");

            b.ToTable("Pilots");
        });

        modelBuilder.Entity<Plane>(b =>
        {
            b.Property<string>("Serial")
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<int>("ModelNumber")
                .HasColumnType("int");

            b.HasKey("Serial");

            b.HasIndex("ModelNumber");

            b.ToTable("Planes");
        });

        modelBuilder.Entity<PlaneModel>(b =>
        {
            b.Property<int>("ModelNumber")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            b.Property<int>("ModelNumber").UseIdentityColumn();

            b.Property<string>("ManufacturerName")
                .IsRequired()
                .HasColumnType("nvarchar(50)");

            b.Property<string>("TypeRating")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.HasKey("ModelNumber");

            b.HasIndex("ManufacturerName");

            b.ToTable("PlaneModels");
        });

        modelBuilder.Entity<StaffWorker>(b =>
        {
            b.Property<int>("Id")
                .ValueGeneratedOnAdd()
                .HasColumnType("int");

            b.Property<int>("Id").UseIdentityColumn();

            b.Property<string>("Address")
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("nvarchar(50)");

            b.Property<string>("Name")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("PhoneNumber")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<string>("Role")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.Property<decimal>("Salary")
                .HasPrecision(8, 2)
                .HasColumnType("decimal(8,2)");

            b.Property<string>("Surname")
                .IsRequired()
                .HasMaxLength(20)
                .HasColumnType("nvarchar(20)");

            b.HasKey("Id");

            b.ToTable("StaffWorkers");
        });

        modelBuilder.Entity("FlightPassenger", b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                .WithMany()
                .HasForeignKey("FlightsFlightId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("Spoonbill.Wpf.Data.Models.Passenger", null)
                .WithMany()
                .HasForeignKey("PassengersId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("FlightPilot", b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                .WithMany()
                .HasForeignKey("AssignedFlightsFlightId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("Spoonbill.Wpf.Data.Models.Pilot", null)
                .WithMany()
                .HasForeignKey("PilotsId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity("FlightStaffWorker", b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                .WithMany()
                .HasForeignKey("AssignedFlightsFlightId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("Spoonbill.Wpf.Data.Models.StaffWorker", null)
                .WithMany()
                .HasForeignKey("WorkerStaffId")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
        });

        modelBuilder.Entity<Airport>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.City", "City")
                .WithMany()
                .HasForeignKey("CityName")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("City");
        });

        modelBuilder.Entity<City>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.County", "County")
                .WithMany()
                .HasForeignKey("CountyName")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("County");
        });

        modelBuilder.Entity<Flight>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.Plane", "Plane")
                .WithMany()
                .HasForeignKey("PlaneSerial")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Plane");
        });

        modelBuilder.Entity<FlightStop>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.Airport", "Airport")
                .WithMany()
                .HasForeignKey("AirportName")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.HasOne("Spoonbill.Wpf.Data.Models.Flight", null)
                .WithMany("Stops")
                .HasForeignKey("FlightId");

            b.Navigation("Airport");
        });

        modelBuilder.Entity<Manufacturer>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.City", "City")
                .WithMany()
                .HasForeignKey("CityName")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("City");
        });

        modelBuilder.Entity<Plane>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.PlaneModel", "Model")
                .WithMany()
                .HasForeignKey("ModelNumber")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Model");
        });

        modelBuilder.Entity<PlaneModel>(b =>
        {
            b.HasOne("Spoonbill.Wpf.Data.Models.Manufacturer", "Manufacturer")
                .WithMany()
                .HasForeignKey("ManufacturerName")
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

            b.Navigation("Manufacturer");
        });

        modelBuilder.Entity<Flight>(b =>
        {
            b.Navigation(e => e.Passengers);
            b.Navigation(e => e.WorkerStaff);
            b.Navigation(e => e.Pilots);
            b.Navigation(e => e.Stops);
        });
    }
}