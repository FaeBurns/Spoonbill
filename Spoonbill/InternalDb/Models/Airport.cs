namespace Spoonbill.InternalDb.Models;

internal partial class Airport
{
    public int AirportId { get; set; }

    public string City { get; set; } = null!;

    public virtual City CityNavigation { get; set; } = null!;

    public virtual ICollection<Stretch> StretchDestAirportNavigations { get; set; } = new List<Stretch>();

    public virtual ICollection<Stretch> StretchSourceAirportNavigations { get; set; } = new List<Stretch>();
}
