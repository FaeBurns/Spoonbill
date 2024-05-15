using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class PassengerReference
{
    public PassengerReference(Passenger passenger)
    {
        Id = passenger.Id;
        FullName = passenger.Name + " " + passenger.Surname;
    }

    public PassengerReference()
    {
        Id = 0;
        FullName = String.Empty;
    }

    public int Id { get; }
    public string FullName { get; }

    public string ViewText => Id + " | " + FullName;
}