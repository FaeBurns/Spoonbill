namespace Spoonbill.Wpf.Data.Models;

public class Passenger : Person
{
    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}