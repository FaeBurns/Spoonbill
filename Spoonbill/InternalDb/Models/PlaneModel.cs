namespace Spoonbill.InternalDb.Models;

internal partial class PlaneModel
{
    public string ModelNumber { get; set; } = null!;

    public string Manufacturer { get; set; } = null!;

    public string TypeRating { get; set; } = null!;

    public virtual Manufacturer ManufacturerNavigation { get; set; } = null!;

    public virtual ICollection<Plane> Planes { get; set; } = new List<Plane>();
}
