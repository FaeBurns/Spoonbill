using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Spoonbill.Database.Entities;

[PrimaryKey(nameof(Id))]
[Table("PERSON")]
public class Person
{
    [Column("person_id")]
    public int Id { get; set; }
    
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = String.Empty;
    
    [Column("surname")]
    [StringLength(50)]
    public string Surname { get; set; } = String.Empty;
    
    [Column("date_of_birth")]
    public DateTime DateOfBirth { get; set; }

    public List<Address> Addresses { get; set; } = new List<Address>();

    public List<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();
}