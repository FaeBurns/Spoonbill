namespace Spoonbill.Database.Entities;

internal partial class County
{
    public string County1 { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<City> Cities { get; set; } = new List<City>();
}
