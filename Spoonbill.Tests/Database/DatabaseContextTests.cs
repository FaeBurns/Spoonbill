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
    }
}