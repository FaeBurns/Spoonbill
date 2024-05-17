using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Interfaces;

public interface IPassengerModule
{
    Passenger? GetPassenger(int id);
    IResult CreatePassenger(Passenger passenger);
    IResult UpdatePassenger(Passenger passenger);
    IResult DeletePassenger(Passenger passenger);
    ICollection<Passenger> ListPassengers();
}