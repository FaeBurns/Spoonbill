using Microsoft.EntityFrameworkCore;
using Spoonbill.Database;
using Spoonbill.Database.Entities;

namespace Spoonbill.Tests.Database;

public class DatabaseContextTests
{
    [Test]
    public void TestDatabaseConnection()
    {
        using SpoonbillContext spoonbillContext = new SpoonbillContext(TestSetup.ConnectionString);
        Assert.That(!spoonbillContext.People.Any());
        
        Person person = new Person()
        {
            Name = "John",
            Surname = "Doe",
            DateOfBirth = DateTime.Today - TimeSpan.FromDays(1),
            Addresses =
            {
                new Address()
                {
                    AddressContent = "address content",
                },
            },
            PhoneNumbers =
            {
                new PhoneNumber()
                {
                    Content = "1234567890",
                }
            },
        };
        spoonbillContext.Add(person);
        
        spoonbillContext.SaveChanges();

        using SpoonbillContext spoonbillContext2 = new SpoonbillContext(TestSetup.ConnectionString);
        Assert.That(spoonbillContext2.People.Count() == 1);

        Person retrievedPerson = spoonbillContext2.People
            .Include(p => p.Addresses)
            .Include(p => p.PhoneNumbers)
            .First();
        Assert.That(retrievedPerson.Name, Is.EqualTo("John"));
        Assert.That(retrievedPerson.Surname, Is.EqualTo("Doe"));
        Assert.That(retrievedPerson.Addresses.Count, Is.EqualTo(1));
        Assert.That(retrievedPerson.PhoneNumbers.Count, Is.EqualTo(1));
        Assert.That(retrievedPerson.Addresses.First().AddressContent == "address content");
        Assert.That(retrievedPerson.PhoneNumbers.First().Content == "1234567890");
    }
}