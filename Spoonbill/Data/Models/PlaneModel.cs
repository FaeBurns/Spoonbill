using System.ComponentModel.DataAnnotations;

namespace Spoonbill.Data.Models;

public class PlaneModel
{
    public int ModelNumber { get; set; }
    public Manufacturer Manufacturer { get; set; } = null!;
    [StringLength(20)]
    public string TypeRating { get; set; } = null!;
}