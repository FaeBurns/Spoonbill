using System.ComponentModel.DataAnnotations;

namespace Spoonbill.Data.Models;

public class City
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
    public County County { get; set; } = null!;
}