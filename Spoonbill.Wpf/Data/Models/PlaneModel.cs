using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(ModelNumber))]
public class PlaneModel
{
    // explicitly enable insert
    [DatabaseGenerated((DatabaseGeneratedOption.None))]
    public int ModelNumber { get; set; }
    [Required]
    public Manufacturer Manufacturer { get; set; } = null!;
    [StringLength(20)]
    public string TypeRating { get; set; } = null!;
}