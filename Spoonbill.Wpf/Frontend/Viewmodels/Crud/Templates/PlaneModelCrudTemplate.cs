using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class PlaneModelCrudTemplate : GenericCrudTemplate<PlaneModel, int>
{
    private readonly IAirplaneModule m_airplaneModule;

    public PlaneModelCrudTemplate(IAirplaneModule airplaneModule) : base(new TabledAirplaneModule(airplaneModule), "PlaneModel")
    {
        m_airplaneModule = airplaneModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new PlaneModelIntrospectViewModel(m_airplaneModule, (PlaneModel)model);
}