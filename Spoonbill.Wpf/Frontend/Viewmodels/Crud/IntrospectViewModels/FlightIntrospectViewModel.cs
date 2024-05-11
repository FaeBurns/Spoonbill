using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class FlightIntrospectViewModel : IntrospectViewModel<Flight>
{
    private readonly IFlightsModule m_flightsModule;
    private readonly IPassengerModule m_passengerModule;



    public FlightIntrospectViewModel(IFlightsModule flightsModule, IPassengerModule passengerModule, Flight model) : base(model)
    {
        m_flightsModule = flightsModule;
        m_passengerModule = passengerModule;

    }

    public override IResult Apply()
    {
        throw new NotImplementedException();
    }
}