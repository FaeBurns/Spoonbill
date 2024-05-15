using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class PlaneCrudTemplate : GenericCrudTemplate<Plane, string>
{
    private readonly IAirplaneModule m_airplaneModule;

    public PlaneCrudTemplate(IAirplaneModule airplaneModule) : base(new TabledAirplaneModule(airplaneModule), "Plane")
    {
        m_airplaneModule = airplaneModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new PlaneIntrospectViewModel(m_airplaneModule, (Plane)model);
}