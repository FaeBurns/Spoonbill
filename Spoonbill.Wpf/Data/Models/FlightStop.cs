using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Id))]
public class FlightStop
{
    public int Id { get; set; } = 0;
    public virtual Airport Airport { get; set; } = null!;
    public int Order { get; set; } = 0;
}