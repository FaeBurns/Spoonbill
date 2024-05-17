using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Tabled;

public class TabledPassengerModule : ITabledCrudModule<Passenger, int>
{
    private readonly IPassengerModule m_passengerModule;

    public TabledPassengerModule(IPassengerModule passengerModule)
    {
        m_passengerModule = passengerModule;
    }

    IResult ITabledCrudModule<Passenger, int>.Create(Passenger model)
    {
        return m_passengerModule.CreatePassenger(model);
    }

    Passenger? ITabledCrudModule<Passenger, int>.Read(int key)
    {
        return m_passengerModule.GetPassenger(key);
    }

    IResult ITabledCrudModule<Passenger, int>.Update(Passenger model)
    {
        return m_passengerModule.UpdatePassenger(model);
    }

    IResult ITabledCrudModule<Passenger, int>.Destroy(Passenger model)
    {
        return m_passengerModule.DeletePassenger(model);
    }

    ICollection<Passenger> ITabledCrudModule<Passenger, int>.List()
    {
        return m_passengerModule.ListPassengers();
    }
}