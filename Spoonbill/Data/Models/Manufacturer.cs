using System.ComponentModel.DataAnnotations;

namespace Spoonbill.Data.Models;

public class Manufacturer
{
    [StringLength(50)]
    public string Name { get; set; } = null!;
    public City City { get; set; } = null!;
}