namespace Spoonbill.Wpf.Controllers.Interfaces;

public interface ISpoonbillContainer
{
    IAirplaneModule AirplaneModule { get; }
    IFlightsModule FlightsModule { get; }
    ILocationsModule LocationsModule { get; }
    IPassengerModule PassengerModule { get; }
    IStaffModule StaffModule { get; }
}