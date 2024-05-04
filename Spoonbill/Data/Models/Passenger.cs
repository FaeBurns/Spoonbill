namespace Spoonbill.Data.Models;

public class Passenger : Person
{
    public ICollection<Flight> Flights { get; set; } = new List<Flight>();
}