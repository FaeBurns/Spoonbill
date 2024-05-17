using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class StaffWorkerCrudTemplate : GenericCrudTemplate<StaffWorker, int>
{
    private readonly IFlightsModule m_flightsModule;

    public StaffWorkerCrudTemplate(ISpoonbillContainer container) : base(new TabledStaffModule(container.StaffModule), "StaffWorker")
    {
        m_flightsModule = container.FlightsModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new StaffWorkerIntrospectViewModel(m_flightsModule, (StaffWorker)model);
}