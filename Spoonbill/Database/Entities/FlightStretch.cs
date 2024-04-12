namespace Spoonbill.Database.Entities;

internal partial class FlightStretch
{
    public int FlightId { get; set; }

    public int StretchId { get; set; }

    public DateTime SourceDepartureTime { get; set; }

    public DateTime DestArrivalTime { get; set; }

    public virtual Flight Flight { get; set; } = null!;

    public virtual Stretch Stretch { get; set; } = null!;
}
