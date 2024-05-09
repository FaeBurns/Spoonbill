using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Controllers;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Tests.Database;

[TestFixture]
[Order(1)]
public class FlightTests : DbTest
{
    [Test]
    public void AddManufacturer_Valid()
    {
        new LocationTests().AddAirport_Valid();
        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        Manufacturer manufacturer = new Manufacturer
        {
            Name = "Manufacturer",
            City = context.Cities.First()
        };
        context.Manufacturers.Add(manufacturer);
        context.SaveChanges();

        Manufacturer foundManufacturer = context.Manufacturers.Include(m => m.City).First(m => m.Name == manufacturer.Name);
        Assert.That(foundManufacturer, Is.Not.Null);
        Assert.That(foundManufacturer.City, Is.Not.Null);
    }

    [Test]
    public void AddPlaneModel_Valid()
    {
        AddManufacturer_Valid();
        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        PlaneModel model = new PlaneModel
        {
            Manufacturer = context.Manufacturers.Find("Manufacturer")!,
            ModelNumber = 3,
            TypeRating = "clown"
        };

        context.PlaneModels.Add(model);
        context.SaveChanges();
        PlaneModel foundModel = context.PlaneModels.Include(m => m.Manufacturer).First(m => m.ModelNumber == 3);
        Assert.That(foundModel, Is.Not.Null);
        Assert.That(foundModel.Manufacturer, Is.Not.Null);
        Assert.That(foundModel.TypeRating, Is.EqualTo("clown"));
    }

    [Test]
    public void AddPlane_Valid()
    {
        AddPlaneModel_Valid();
        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        Plane plane = new Plane
        {
            Model = context.PlaneModels.First(),
            Serial = "PlaneSerial:33"
        };

        context.Planes.Add(plane);
        context.SaveChanges();
        Plane foundPlane = context.Planes.Include(p => p.Model).First(p => p.Serial == plane.Serial);
        Assert.That(foundPlane, Is.Not.Null);
        Assert.That(foundPlane.Model, Is.Not.Null);
    }

    [Test]
    public void AddFlight_Valid()
    {
        // ensure that valid inputs exist
        new PassengerTests().AddPassenger_Valid();
        AddPlane_Valid();

        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        Flight flight = new Flight
        {
            Name = "Flight Name",
            Passengers =
            {
                context.Passengers.First()
            },
            ArrivalTime = DateTime.UtcNow + TimeSpan.FromHours(5),
            DepartureTime = DateTime.UtcNow,
            Stops =
            {
                new FlightStop
                {
                    Airport = context.Airports.Find(LocationTests.ValidAirportName)!,
                    Order = 0
                },
                new FlightStop
                {
                    Airport = context.Airports.Find(LocationTests.ValidAirportName)!,
                    Order = 1
                }
            },
            Plane = context.Planes.Find("PlaneSerial:33")!,
            Pilots =
            {
                new Pilot
                {
                    Address = "3",
                    Name = "Johnny",
                    Surname = "Gunthorpe",
                    Salary = 2.33m,
                    PhoneNumber = "69",
                    TypeRating = "12"
                }
            },
            WorkerStaff =
            {
                new StaffWorker
                {
                    Address = "2",
                    Name = "Test",
                    Surname = "Worker",
                    Role = "Clown",
                    Salary = 59930.12m,
                    PhoneNumber = "UNKNOWN"
                }
            }
        };

        new FlightsModule(context).CreateFlight(flight);
    }
}