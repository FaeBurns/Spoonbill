namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class PassengerReference
{
    public PassengerReference(int id, string name, string surname)
    {
        Id = id;
        Name = name;
        Surname = surname;
    }

    public int Id { get; }
    public string Name { get; }
    public string Surname { get; }
    public string FullName => Name + " " + Surname;
}