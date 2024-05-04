using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Spoonbill.Data.Models;

public class Flight
{
    public Plane Plane { get; set; } = null!;
    [StringLength(20)]
    public string Name { get; set; } = null!;
    public ICollection<Passenger> Passengers { get; set; }= new List<Passenger>();
    public ICollection<StaffWorker> WorkerStaff { get; set; } = new List<StaffWorker>();
    public ICollection<Pilot> Pilots { get; set; } = new List<Pilot>();
    public ICollection<Airport> Airports { get; set; } = new List<Airport>();
    public DateTime DepartureTime { get; set; }
    public DateTime ArrivalTime { get; set; }

    public TimeSpan GetDuration()
    {
        return ArrivalTime - DepartureTime;
    }
}