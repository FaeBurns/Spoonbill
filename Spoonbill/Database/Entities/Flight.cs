namespace Spoonbill.Database.Entities;

internal partial class Flight
{
    public int FlightId { get; set; }

    public string PlaneSerial { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? RepeatInterval { get; set; }

    public virtual ICollection<FlightStretch> FlightStretches { get; set; } = new List<FlightStretch>();

    public virtual Plane PlaneSerialNavigation { get; set; } = null!;

    public virtual ICollection<Person> Passengers { get; set; } = new List<Person>();

    public virtual ICollection<Staff> Staff { get; set; } = new List<Staff>();
}
