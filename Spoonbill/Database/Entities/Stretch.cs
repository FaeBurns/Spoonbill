namespace Spoonbill.Database.Entities;

internal partial class Stretch
{
    public int StretchId { get; set; }

    public int SourceAirport { get; set; }

    public int DestAirport { get; set; }

    public virtual Airport DestAirportNavigation { get; set; } = null!;

    public virtual ICollection<FlightStretch> FlightStretches { get; set; } = new List<FlightStretch>();

    public virtual Airport SourceAirportNavigation { get; set; } = null!;
}
