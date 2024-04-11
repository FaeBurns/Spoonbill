using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Database.Entities;

// ReSharper disable once StringLiteralTypo
[Table("PHONENUMBERS")]
[PrimaryKey(nameof(PersonId), nameof(Content))]
public class PhoneNumber
{
    [Column("phone_number")]
    [StringLength(20)]
    public string Content { get; set; } = String.Empty;
    
    [Column("person_id")]
    [ForeignKey(nameof(Person))]
    public int PersonId { get; set; }

    public Person Person { get; set; } = null!;
}