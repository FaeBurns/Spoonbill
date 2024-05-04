using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Data;

public class SpoonbillContext : DbContext
{
    private readonly string m_connectionString;

    public SpoonbillContext(string connectionString)
    {
        m_connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(m_connectionString).EnableSensitiveDataLogging();
    }
}