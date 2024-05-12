using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class PilotReference
{
    public int Id { get; }
    public string FullName { get; }

    public string TypeRating { get; }

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