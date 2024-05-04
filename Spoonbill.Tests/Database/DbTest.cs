namespace Spoonbill.Tests.Database;

public abstract class DbTest
{
    [SetUp]
    public void Setup()
    {
        TestSetup.ClearDatabase();
    }
}