namespace Spoonbill.InternalDb.Models;

internal partial class Plane
{
    public string PlaneSerial { get; set; } = null!;

    public string ModelNumber { get; set; } = null!;

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();

    public virtual PlaneModel ModelNumberNavigation { get; set; } = null!;
}
