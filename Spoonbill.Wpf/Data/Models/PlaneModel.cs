using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(ModelNumber))]
public class PlaneModel
{
    public int ModelNumber { get; set; }
    [Required]
    public Manufacturer Manufacturer { get; set; } = null!;
    [StringLength(20)]
    public string TypeRating { get; set; } = null!;
}