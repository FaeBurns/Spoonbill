namespace Spoonbill.Database.Entities;

internal partial class PhoneNumber
{
    public int PersonId { get; set; }

    public string Content { get; set; } = null!;

    public virtual Person Person { get; set; } = null!;
}
