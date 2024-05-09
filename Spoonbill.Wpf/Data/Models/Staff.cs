using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

public abstract class Staff : Person
{
    public ICollection<Flight> AssignedFlights { get; set; } = new List<Flight>();

    [Precision(8, 2)]
    public decimal Salary { get; set; }
}