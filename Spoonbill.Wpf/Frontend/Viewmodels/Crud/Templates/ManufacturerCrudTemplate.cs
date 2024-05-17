using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class ManufacturerCrudTemplate : GenericCrudTemplate<Manufacturer, string>
{
    private readonly ILocationsModule m_locationsModule;

    public ManufacturerCrudTemplate(ISpoonbillContainer container) : base(new TabledAirplaneModule(container.AirplaneModule), "Manufacturer")
    {
        m_locationsModule = container.LocationsModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new ManufacturerIntrospectViewModel(m_locationsModule, (Manufacturer)model);
}