using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Interfaces;

public interface IFlightsModule
{
    Flight? GetFlight(int id);
    IResult CreateFlight(Flight flight);
    IResult UpdateFlight(Flight flight);
    IResult DeleteFlight(Flight flight);
    ICollection<Flight> ListFlights();
}