using System.ComponentModel.DataAnnotations;

namespace Spoonbill.Wpf.Data.Models;

public class StaffWorker : Staff
{
    [StringLength(20)]
    public string Role { get; set; } = null!;
}