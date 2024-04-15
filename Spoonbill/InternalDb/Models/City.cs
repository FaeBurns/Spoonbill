namespace Spoonbill.InternalDb.Models;

internal partial class City
{
    public string City1 { get; set; } = null!;

    public string County { get; set; } = null!;

    public virtual ICollection<Airport> Airports { get; set; } = new List<Airport>();

    public virtual County CountyNavigation { get; set; } = null!;

    public virtual ICollection<Manufacturer> Manufacturers { get; set; } = new List<Manufacturer>();
}
