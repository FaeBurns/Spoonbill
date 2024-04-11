using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Spoonbill.Database.Entities;

namespace Spoonbill.Database;

public class SpoonbillContext : DbContext
{
    private readonly string m_connectionString;
    
    public DbSet<Address> Addresses { get; set; } = null!;
    public DbSet<PhoneNumber> PhoneNumbers { get; set; } = null!;
    public DbSet<Person> People { get; set; } = null!;

    public SpoonbillContext()
    {
    }
    
    public SpoonbillContext(string connectionString) : this()
    {
        m_connectionString = connectionString;
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(m_connectionString);
    }
}