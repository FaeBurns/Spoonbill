// using Microsoft.EntityFrameworkCore;
// using Spoonbill.InternalDb.Database;
// using Spoonbill.InternalDb.Models;
//
// namespace Spoonbill.Tests.Database.Entities;
//
// public class PersonTests
// {
//     [Test]
//     public void AddPerson()
//     {
//         using SpoonbillContext context = new SpoonbillContext(TestSetup.ConnectionString);
//
//         int count = context.People.Count();
//         TestContext.WriteLine(count);
//
//         Person person = new Person()
//         {
//             Name = "Jenny",
//             Surname = "Doe",
//             DateOfBirth = DateTime.Today - TimeSpan.FromDays(1),
//             Addresses =
//             {
//                 new Address()
//                 {
//                     AddressContent = "address content",
//                 },
//             },
//             PhoneNumbers =
//             {
//                 new PhoneNumber()
//                 {
//                     Content = "1234567890",
//                 },
//             },
//         };
//         context.Add(person);
//         context.SaveChanges();
//
//         using SpoonbillContext context2 = new SpoonbillContext(TestSetup.ConnectionString);
//         Assert.That(context2.People.Count() == count + 1);
//
//         Person retrievedPerson = context2.People
//             .Include(p => p.Addresses)
//             .Include(p => p.PhoneNumbers)
//             .First(p => p.Name == "Jenny" && p.Surname == "Doe");
//         Assert.That(retrievedPerson.Name, Is.EqualTo("Jenny"));
//         Assert.That(retrievedPerson.Surname, Is.EqualTo("Doe"));
//         Assert.That(retrievedPerson.Addresses.Count, Is.EqualTo(1));
//         Assert.That(retrievedPerson.PhoneNumbers.Count, Is.EqualTo(1));
//         Assert.That(retrievedPerson.Addresses.First().AddressContent == "address content");
//         Assert.That(retrievedPerson.PhoneNumbers.First().Content == "1234567890");
//     }
//
//     [Test]
//     public void AddMultiple()
//     {
//         using SpoonbillContext context = new SpoonbillContext(TestSetup.ConnectionString);
//
//         int count = context.People.Count();
//         TestContext.WriteLine(count);
//         DateTime currentDate = DateTime.UtcNow;
//
//         Person person = new Person()
//         {
//             Name = "John",
//             Surname = "Doe",
//             DateOfBirth = currentDate.Add(TimeSpan.FromDays(1)),
//         };
//         Person person2 = new Person()
//         {
//             Name = "Jane",
//             Surname = "Day",
//             DateOfBirth = currentDate.Subtract(TimeSpan.FromDays(1)),
//         };
//         context.Add(person);
//         context.SaveChanges();
//         context.Add(person2);
//         context.SaveChanges();
//
//         using SpoonbillContext context2 = new SpoonbillContext(TestSetup.ConnectionString);
//         Assert.That(context2.People.Count() == count + 2);
//
//         Person retrievedPerson = context2.People
//             .Include(p => p.Addresses)
//             .Include(p => p.PhoneNumbers)
//             .First(p => p.Name.Equals("John") && p.Surname.Equals("Doe"));
//         Assert.That(retrievedPerson.Name, Is.EqualTo("John"));
//         Assert.That(retrievedPerson.Surname, Is.EqualTo("Doe"));
//         // Assert.That(retrievedPerson.DateOfBirth, Is.EqualTo(currentDate.Add(TimeSpan.FromDays(1))));
//         Assert.That(retrievedPerson.Addresses.Count, Is.EqualTo(0));
//         Assert.That(retrievedPerson.PhoneNumbers.Count, Is.EqualTo(0));
//
//         Person retrievedPerson2 = context2.People
//             .Include(p => p.Addresses)
//             .Include(p => p.PhoneNumbers)
//             .First(p => p.Name.Equals("Jane") && p.Surname.Equals("Day"));
//         Assert.That(retrievedPerson2.Name, Is.EqualTo("Jane"));
//         Assert.That(retrievedPerson2.Surname, Is.EqualTo("Day"));
//         // Assert.That(retrievedPerson2.DateOfBirth, Is.EqualTo(currentDate.Subtract(TimeSpan.FromDays(1))));
//         Assert.That(retrievedPerson2.Addresses.Count, Is.EqualTo(0));
//         Assert.That(retrievedPerson2.PhoneNumbers.Count, Is.EqualTo(0));
//     }
// }