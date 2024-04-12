namespace Spoonbill.Database.Entities;

internal partial class Person
{
    public int PersonId { get; set; }

    public string Name { get; set; } = null!;

    public string Surname { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();

    public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; } = new List<PhoneNumber>();

    public virtual Staff? Staff { get; set; }

    public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
}
