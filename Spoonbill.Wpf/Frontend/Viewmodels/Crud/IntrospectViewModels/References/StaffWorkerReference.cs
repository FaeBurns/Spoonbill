using JetBrains.Annotations;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

[UsedImplicitly(ImplicitUseKindFlags.Access, ImplicitUseTargetFlags.Members)]
public class StaffWorkerReference
{
    private bool Equals(StaffWorkerReference other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((StaffWorkerReference)obj);
    }

    public override int GetHashCode()
    {
        return Id;
    }

    public int Id { get; }
    public string Role { get; }
    public string FullName { get; }

    public string ViewText => $"{Id} | {FullName} | {Role}";

    public StaffWorkerReference(StaffWorker staffWorker)
    {
        Id = staffWorker.Id;
        Role = staffWorker.Role;
        FullName = staffWorker.Name + " " + staffWorker.Surname;
    }

    public StaffWorkerReference()
    {
        Id = 0;
        Role = String.Empty;
        FullName = String.Empty;
    }
}