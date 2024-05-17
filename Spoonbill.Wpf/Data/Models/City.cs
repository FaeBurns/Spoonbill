using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Name))]
public class City
{
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Required]
    public virtual County County { get; set; } = null!;
}