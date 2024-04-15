namespace Spoonbill.InternalDb.Models;

internal partial class PilotRating
{
    public int StaffId { get; set; }

    public string Rating { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
