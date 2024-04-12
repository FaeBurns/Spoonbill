namespace Spoonbill.Database.Entities;

internal partial class Address
{
    public int PersonId { get; set; }

    public string AddressContent { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
