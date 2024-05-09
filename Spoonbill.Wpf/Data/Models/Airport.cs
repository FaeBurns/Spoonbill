using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Name))]
public class Airport
{
    [StringLength(20)]
    public string Name { get; set; } = null!;

    [Required]
    public City City { get; set; } = null!;
}