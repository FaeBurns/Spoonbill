using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Spoonbill.Wpf.Data;

[ExcludeFromCodeCoverage]
public class SpoonbillContextFactory : IDesignTimeDbContextFactory<SpoonbillContext>
{
    public SpoonbillContext CreateDbContext(string[] args)
    {
        DbContextOptionsBuilder<SpoonbillContext> optionsBuilder = new DbContextOptionsBuilder<SpoonbillContext>();
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=spoonbill_dev;User Id=SA;Password=S3cureDb$Password;Trust Server Certificate=True;Integrated Security=False");
        return new SpoonbillContext(optionsBuilder.Options);
    }
}