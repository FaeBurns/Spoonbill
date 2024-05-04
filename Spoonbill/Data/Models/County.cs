using System.ComponentModel.DataAnnotations;

namespace Spoonbill.Data.Models;

public class County
{
    [StringLength(20)]
    public string Name { get; set; } = null!;
    [StringLength(20)]
    public string Country { get; set; } = null!;
}