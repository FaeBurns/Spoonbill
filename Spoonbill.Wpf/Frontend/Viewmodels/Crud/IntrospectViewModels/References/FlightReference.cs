using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class FlightReference
{
    public FlightReference(Flight flight)
    {
        Id = flight.FlightId;
        Name = flight.Name;
    }

    public FlightReference(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; init; }
    public string Name { get; init; }
}