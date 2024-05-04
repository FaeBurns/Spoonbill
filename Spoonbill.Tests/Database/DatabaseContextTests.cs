using Spoonbill.Data;

namespace Spoonbill.Tests.Database;

public class DatabaseContextTests
{
    [Test]
    public void TestDatabaseConnection()
    {
        using SpoonbillContext spoonbillContext = new SpoonbillContext(TestSetup.ConnectionString);
    }
}