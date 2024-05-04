using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Name))]
public class Manufacturer
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
    [Required]
    public City City { get; set; } = null!;
}