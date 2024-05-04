using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Tests.Database;

public class PassengerTests : DbTest
{
    [Test]
    public void AddPassenger_Valid()
    {
        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        int count = context.Passengers.Count();

        Passenger passenger = new Passenger()
        {
            Name = "Jane",
            Surname = "Doe",
            Address = "4",
            PhoneNumber = "1337",
        };

        context.Passengers.Add(passenger);
        context.SaveChanges();

        Assert.That(context.Passengers.Count(), Is.EqualTo(count + 1));

        Passenger? foundPassenger = context.Passengers.Find(passenger.Id);
        Assert.That(foundPassenger, Is.Not.Null);
        Assert.That(foundPassenger.Name, Is.EqualTo(passenger.Name));
        Assert.That(foundPassenger.Surname, Is.EqualTo(passenger.Surname));
        Assert.That(foundPassenger.Address, Is.EqualTo(passenger.Address));
        Assert.That(foundPassenger.PhoneNumber, Is.EqualTo(passenger.PhoneNumber));
    }
}