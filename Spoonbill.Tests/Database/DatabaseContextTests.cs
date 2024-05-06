using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Controllers;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Tests.Database;

public class DatabaseContextTests : DbTest
{
    [Test]
    public void TestDatabaseConnection()
    {
        using SpoonbillContext spoonbillContext = new SpoonbillContext(TestSetup.Options);
    }

    [Test]
    public void WorkingTest()
    {
        new FlightTests().AddFlight_Valid();
        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        FlightsModule flightsModule = new FlightsModule(context);
        ICollection<Flight> flights = flightsModule.ListFlights();
    }
}