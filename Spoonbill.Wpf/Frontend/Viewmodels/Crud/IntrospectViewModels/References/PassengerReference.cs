using JetBrains.Annotations;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

[UsedImplicitly(ImplicitUseKindFlags.Access, ImplicitUseTargetFlags.Members)]
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

    public override bool Equals(object? obj)
    {
        return Equals(obj as PassengerReference);
    }

    private bool Equals(PassengerReference? other)
    {
        if (other == null)
            return false;
        return Id == other.Id;
    }

    public override int GetHashCode()
    {
        return Id;
    }
}