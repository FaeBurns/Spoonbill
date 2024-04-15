using Microsoft.EntityFrameworkCore;
using Spoonbill.InternalDb.Database;

namespace Spoonbill.Tests.Database;

public class DatabaseContextTests
{
    [Test]
    public void TestDatabaseConnection()
    {
        using SpoonbillContext spoonbillContext = new SpoonbillContext(TestSetup.ConnectionString);
    }
}