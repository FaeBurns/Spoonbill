using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Data.Models;

public class StaffWorker : Staff
{
    [StringLength(20)]
    public string Role { get; set; } = null!;
}