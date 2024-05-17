using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class PilotCrudTemplate : GenericCrudTemplate<Pilot, int>
{
    private readonly IFlightsModule m_flightsModule;

    public PilotCrudTemplate(ISpoonbillContainer container) : base(new TabledStaffModule(container.StaffModule), "Pilots")
    {
        m_flightsModule = container.FlightsModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new PilotIntrospectViewModel(m_flightsModule, (Pilot)model);
}