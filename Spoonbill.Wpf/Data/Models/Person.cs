using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Wpf.Data.Models;

[PrimaryKey(nameof(Id))]
public abstract class Person
{
    public int Id { get; set; }

    [StringLength(20)]
    public string Name { get; set; } = null!;

    [StringLength(20)]
    public string Surname { get; set; } = null!;

    [StringLength(20)]
    public string PhoneNumber { get; set; } = null!;

    [StringLength(50)]
    public string Address { get; set; } = null!;
}