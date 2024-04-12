using Microsoft.EntityFrameworkCore;
using Spoonbill.Database.Entities;

namespace Spoonbill.Database;

internal partial class SpoonbillContext : DbContext
{
    private readonly string m_connectionString;

    public SpoonbillContext(string connectionString)
    {
        m_connectionString = connectionString;
    }

    public virtual DbSet<Address> Addresses { get; set; } = null!;

    public virtual DbSet<Airport> Airports { get; set; } = null!;

    public virtual DbSet<City> Cities { get; set; } = null!;

    public virtual DbSet<County> Counties { get; set; } = null!;

    public virtual DbSet<Flight> Flights { get; set; } = null!;

    public virtual DbSet<FlightStretch> FlightStretches { get; set; } = null!;

    public virtual DbSet<Manufacturer> Manufacturers { get; set; } = null!;

    public virtual DbSet<Person> People { get; set; } = null!;

    public virtual DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;

    public virtual DbSet<PilotRating> PilotRatings { get; set; } = null!;

    public virtual DbSet<Plane> Planes { get; set; } = null!;

    public virtual DbSet<PlaneModel> PlaneModels { get; set; } = null!;

    public virtual DbSet<Staff> Staff { get; set; } = null!;

    public virtual DbSet<Stretch> Stretches { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(m_connectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, Address1 = e.AddressContent });

            entity.ToTable("ADDRESSES");

            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.AddressContent)
                .HasColumnType("varchar(50)")
                .HasColumnName("address");

            entity.HasOne(d => d.Person).WithMany(p => p.Addresses).HasForeignKey(d => d.PersonId);
        });

        modelBuilder.Entity<Airport>(entity =>
        {
            entity.ToTable("AIRPORTS");

            entity.Property(e => e.AirportId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("airport_id");
            entity.Property(e => e.City)
                .HasColumnType("varchar(50)")
                .HasColumnName("city");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Airports)
                .HasForeignKey(d => d.City)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.City1);

            entity.ToTable("CITIES");

            entity.Property(e => e.City1)
                .HasColumnType("varchar(50)")
                .HasColumnName("city");
            entity.Property(e => e.County)
                .HasColumnType("varchar(50)")
                .HasColumnName("county");

            entity.HasOne(d => d.CountyNavigation).WithMany(p => p.Cities)
                .HasForeignKey(d => d.County)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<County>(entity =>
        {
            entity.HasKey(e => e.County1);

            entity.ToTable("COUNTIES");

            entity.Property(e => e.County1)
                .HasColumnType("varchar(50)")
                .HasColumnName("county");
            entity.Property(e => e.Country)
                .HasColumnType("varchar(50)")
                .HasColumnName("country");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.ToTable("FLIGHTS");

            entity.Property(e => e.FlightId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("flight_id");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(20)")
                .HasColumnName("name");
            entity.Property(e => e.PlaneSerial)
                .HasColumnType("varchar(30)")
                .HasColumnName("plane_serial");
            entity.Property(e => e.RepeatInterval)
                .HasColumnType("varchar(50)")
                .HasColumnName("repeat_interval");

            entity.HasOne(d => d.PlaneSerialNavigation).WithMany(p => p.Flights)
                .HasForeignKey(d => d.PlaneSerial)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasMany(d => d.Passengers).WithMany(p => p.Flights)
                .UsingEntity<Dictionary<string, object>>(
                    "FlightPassenger",
                    r => r.HasOne<Person>().WithMany().HasForeignKey("PassengerId"),
                    l => l.HasOne<Flight>().WithMany().HasForeignKey("FlightId"),
                    j =>
                    {
                        j.HasKey("FlightId", "PassengerId");
                        j.ToTable("FLIGHT_PASSENGERS");
                        j.IndexerProperty<int>("FlightId")
                            .HasColumnType("INT")
                            .HasColumnName("flight_id");
                        j.IndexerProperty<int>("PassengerId")
                            .HasColumnType("INT")
                            .HasColumnName("passenger_id");
                    });

            entity.HasMany(d => d.Staff).WithMany(p => p.Flights)
                .UsingEntity<Dictionary<string, object>>(
                    "FlightCrew",
                    r => r.HasOne<Staff>().WithMany().HasForeignKey("StaffId"),
                    l => l.HasOne<Flight>().WithMany().HasForeignKey("FlightId"),
                    j =>
                    {
                        j.HasKey("FlightId", "StaffId");
                        j.ToTable("FLIGHT_CREW");
                        j.IndexerProperty<int>("FlightId")
                            .HasColumnType("INT")
                            .HasColumnName("flight_id");
                        j.IndexerProperty<int>("StaffId")
                            .HasColumnType("INT")
                            .HasColumnName("staff_id");
                    });
        });

        modelBuilder.Entity<FlightStretch>(entity =>
        {
            entity.HasKey(e => new { e.FlightId, e.StretchId });

            entity.ToTable("FLIGHT_STRETCHES");

            entity.Property(e => e.FlightId)
                .HasColumnType("INT")
                .HasColumnName("flight_id");
            entity.Property(e => e.StretchId)
                .HasColumnType("INT")
                .HasColumnName("stretch_id");
            entity.Property(e => e.DestArrivalTime)
                .HasColumnType("datetime")
                .HasColumnName("dest_arrival_time");
            entity.Property(e => e.SourceDepartureTime)
                .HasColumnType("datetime")
                .HasColumnName("source_departure_time");

            entity.HasOne(d => d.Flight).WithMany(p => p.FlightStretches).HasForeignKey(d => d.FlightId);

            entity.HasOne(d => d.Stretch).WithMany(p => p.FlightStretches)
                .HasForeignKey(d => d.StretchId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.Manufacturer1);

            entity.ToTable("MANUFACTURERS");

            entity.Property(e => e.Manufacturer1)
                .HasColumnType("varchar(30)")
                .HasColumnName("manufacturer");
            entity.Property(e => e.City)
                .HasColumnType("varchar(50)")
                .HasColumnName("city");

            entity.HasOne(d => d.CityNavigation).WithMany(p => p.Manufacturers)
                .HasForeignKey(d => d.City)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.ToTable("PERSON");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("datetime")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.Name)
                .HasColumnType("varchar(50)")
                .HasColumnName("name");
            entity.Property(e => e.Surname)
                .HasColumnType("varchar(50)")
                .HasColumnName("surname");
        });

        modelBuilder.Entity<PhoneNumber>(entity =>
        {
            entity.HasKey(e => new { e.PersonId, PhoneNumber1 = e.Content });

            entity.ToTable("PHONENUMBERS");

            entity.Property(e => e.PersonId)
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.Content)
                .HasColumnType("varchar(20)")
                .HasColumnName("phone_number");

            entity.HasOne(d => d.Person).WithMany(p => p.PhoneNumbers).HasForeignKey(d => d.PersonId);
        });

        modelBuilder.Entity<PilotRating>(entity =>
        {
            entity.HasKey(e => new { e.StaffId, e.Rating });

            entity.ToTable("PILOT_RATINGS");

            entity.Property(e => e.StaffId)
                .HasColumnType("INT")
                .HasColumnName("staff_id");
            entity.Property(e => e.Rating)
                .HasColumnType("varchar(20)")
                .HasColumnName("rating");

            entity.HasOne(d => d.Staff).WithMany(p => p.PilotRatings).HasForeignKey(d => d.StaffId);
        });

        modelBuilder.Entity<Plane>(entity =>
        {
            entity.HasKey(e => e.PlaneSerial);

            entity.ToTable("PLANES");

            entity.Property(e => e.PlaneSerial)
                .HasColumnType("varchar(30)")
                .HasColumnName("plane_serial");
            entity.Property(e => e.ModelNumber)
                .HasColumnType("varchar(30)")
                .HasColumnName("model_number");

            entity.HasOne(d => d.ModelNumberNavigation).WithMany(p => p.Planes)
                .HasForeignKey(d => d.ModelNumber)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<PlaneModel>(entity =>
        {
            entity.HasKey(e => e.ModelNumber);

            entity.ToTable("PLANE_MODELS");

            entity.Property(e => e.ModelNumber)
                .HasColumnType("varchar(30)")
                .HasColumnName("model_number");
            entity.Property(e => e.Manufacturer)
                .HasColumnType("varchar(30)")
                .HasColumnName("manufacturer");
            entity.Property(e => e.TypeRating)
                .HasColumnType("varchar(20)")
                .HasColumnName("type_rating");

            entity.HasOne(d => d.ManufacturerNavigation).WithMany(p => p.PlaneModels)
                .HasForeignKey(d => d.Manufacturer)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.PersonId);

            entity.ToTable("STAFF");

            entity.Property(e => e.PersonId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("person_id");
            entity.Property(e => e.Role)
                .HasColumnType("varchar(50)")
                .HasColumnName("role");
            entity.Property(e => e.Salary)
                .HasColumnType("numeric(8, 2)")
                .HasColumnName("salary");

            entity.HasOne(d => d.Person).WithOne(p => p.Staff).HasForeignKey<Staff>(d => d.PersonId);
        });

        modelBuilder.Entity<Stretch>(entity =>
        {
            entity.ToTable("STRETCHES");

            entity.Property(e => e.StretchId)
                .ValueGeneratedNever()
                .HasColumnType("INT")
                .HasColumnName("stretch_id");
            entity.Property(e => e.DestAirport)
                .HasColumnType("INT")
                .HasColumnName("dest_airport");
            entity.Property(e => e.SourceAirport)
                .HasColumnType("INT")
                .HasColumnName("source_airport");

            entity.HasOne(d => d.DestAirportNavigation).WithMany(p => p.StretchDestAirportNavigations)
                .HasForeignKey(d => d.DestAirport)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SourceAirportNavigation).WithMany(p => p.StretchSourceAirportNavigations)
                .HasForeignKey(d => d.SourceAirport)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
