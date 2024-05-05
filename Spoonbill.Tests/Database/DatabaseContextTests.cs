using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Controllers;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Tests.Database;

public class DatabaseContextTests
{
    [Test]
    public void TestDatabaseConnection()
    {
        using SpoonbillContext spoonbillContext = new SpoonbillContext(TestSetup.Options);
    }
}