using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;

namespace Spoonbill.Wpf.Controllers;

public class SpoonbillContainer : ISpoonbillContainer
{
    public SpoonbillContainer(SpoonbillContext context)
    {
        AirplaneModule = new AirplaneModule(context);
        FlightsModule = new FlightsModule(context);
        LocationsModule = new LocationsModule(context);
        PassengerModule = new PassengerModule(context);
        StaffModule = new StaffModule(context);
    }

    public IAirplaneModule AirplaneModule { get; }
    public IFlightsModule FlightsModule { get; }
    public ILocationsModule LocationsModule { get; }
    public IPassengerModule PassengerModule { get; }
    public IStaffModule StaffModule { get; }
}