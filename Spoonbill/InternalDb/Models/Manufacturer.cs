namespace Spoonbill.InternalDb.Models;

internal partial class Manufacturer
{
    public string Manufacturer1 { get; set; } = null!;

    public string City { get; set; } = null!;

    public virtual City CityNavigation { get; set; } = null!;

    public virtual ICollection<PlaneModel> PlaneModels { get; set; } = new List<PlaneModel>();
}
