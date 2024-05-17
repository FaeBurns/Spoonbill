using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class FlightReference
{
    private bool Equals(FlightReference other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((FlightReference)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public FlightReference(Flight flight)
    {
        Id = flight.FlightId;
        Name = flight.Name;
    }

    public FlightReference()
    {
        Id = 0;
        Name = String.Empty;
    }

    public int Id { get; init; }
    public string Name { get; init; }
    public string ViewText => Id + " | " + Name;
}