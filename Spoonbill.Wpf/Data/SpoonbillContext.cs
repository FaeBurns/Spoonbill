using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Data;

public class SpoonbillContext : DbContext
{
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

    public SpoonbillContext(DbContextOptions<SpoonbillContext> options) : base(options)
    {
    }
}