using System.ComponentModel.DataAnnotations;

namespace Spoonbill.Wpf.Data.Models;

public class Pilot : Staff
{
    [StringLength(20)]
    public string TypeRating { get; set; } = null!;
}