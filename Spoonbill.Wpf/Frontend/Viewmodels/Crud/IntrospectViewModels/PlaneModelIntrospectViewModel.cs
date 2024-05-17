using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class PlaneModelIntrospectViewModel : IntrospectViewModel<PlaneModel>
{
    private readonly IAirplaneModule m_airplaneModule;
    
    public int ModelNumber { get; set; }
    public string TypeRating { get; set; }
    public string Manufacturer { get; set; }
    
    public LazyLoadViewModel<IEnumerable<string>> AvailableManufacturers { get; }
    
    public PlaneModelIntrospectViewModel(IAirplaneModule airplaneModule, PlaneModel model) : base(model)
    {
        m_airplaneModule = airplaneModule;
        ModelNumber = model.ModelNumber;
        TypeRating = model.TypeRating ?? String.Empty;
        Manufacturer = model.Manufacturer?.Name ?? String.Empty;

        AvailableManufacturers = new LazyLoadViewModel<IEnumerable<string>>(() =>
        {
            return m_airplaneModule.ListManufacturers().Select(m => m.Name);
        });
    }

    public override IResult Apply()
    {
        Manufacturer? targetManufacturer = m_airplaneModule.GetManufacturer(Manufacturer);
        if (targetManufacturer == null)
            return new Invalid($"Target Manufacturer {Manufacturer} is not present in database");

        Model.ModelNumber = ModelNumber;
        Model.Manufacturer = targetManufacturer;
        Model.TypeRating = TypeRating;

        return new Ok();
    }
}