using JetBrains.Annotations;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

[UsedImplicitly(ImplicitUseKindFlags.Access, ImplicitUseTargetFlags.Members)]
public class PilotReference
{
    private bool Equals(PilotReference other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((PilotReference)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public int Id { get; }
    public string FullName { get; }

    public string TypeRating { get; }

    public string ViewText => $"{Id} | {FullName} | {TypeRating}";

    public PilotReference(Pilot pilot)
    {
        Id = pilot.Id;
        FullName = pilot.Name + " " + pilot.Surname;
        TypeRating = pilot.TypeRating;
    }

    public PilotReference()
    {
        Id = 0;
        FullName = String.Empty;
        TypeRating = String.Empty;
    }
}