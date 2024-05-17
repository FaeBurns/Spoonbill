using JetBrains.Annotations;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

[UsedImplicitly(ImplicitUseKindFlags.Access, ImplicitUseTargetFlags.Members)]
public class AirportReference
{
    protected bool Equals(AirportReference other)
    {
        return Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((AirportReference)obj);
    }

    public override int GetHashCode()
    {
        return Name.GetHashCode();
    }

    public string Name { get; }

    public AirportReference(Airport airport)
    {
        Name = airport.Name;
    }

    public AirportReference()
    {
        Name = String.Empty;
    }
}