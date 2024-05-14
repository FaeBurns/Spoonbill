using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class PassengerCrudTemplate : GenericCrudTemplate<Passenger, int>
{
    private readonly IFlightsModule m_flightsModule;

    public PassengerCrudTemplate(ISpoonbillContainer container) : base(new TabledPassengerModule(container.PassengerModule), "Passengers")
    {
        m_flightsModule = container.FlightsModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new PassengerIntrospectViewModel(m_flightsModule, (Passenger)model); 
}