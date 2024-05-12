using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class StaffWorkerReference
{
    public int Id { get; }
    public string Role { get; }
    public string FullName { get; }

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