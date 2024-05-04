using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Name))]
public class County
{
    [StringLength(20)]
    public string Name { get; set; } = null!;
    [StringLength(20)]
    public string Country { get; set; } = null!;
}