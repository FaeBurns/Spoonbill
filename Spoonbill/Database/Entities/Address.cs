using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Database.Entities;

[Table("ADDRESSES")]
[PrimaryKey(nameof(AddressContent), nameof(PersonId))]
public class Address
{
    [Column("address")]
    [StringLength(50)]
    public string AddressContent { get; set; } = String.Empty;
    
    [Column("person_id")]
    [ForeignKey(nameof(Person))]
    public int PersonId { get; set; }

    public Person Person { get; set; } = null!;
}