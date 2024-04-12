namespace Spoonbill.Database.Entities;

internal partial class Staff
{
    public int PersonId { get; set; }

    public decimal Salary { get; set; }

    public string Role { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;

    public virtual ICollection<PilotRating> PilotRatings { get; set; } = new List<PilotRating>();

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
