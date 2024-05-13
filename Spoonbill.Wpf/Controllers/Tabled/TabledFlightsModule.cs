using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Tabled;

public class TabledFlightsModule : ITabledCrudModule<Flight, int>
{
    private readonly IFlightsModule m_flightsModule;

    public TabledFlightsModule(IFlightsModule flightsModule)
    {
        m_flightsModule = flightsModule;
    }
    
    IResult ITabledCrudModule<Flight, int>.Create(Flight model)
    {
        return m_flightsModule.CreateFlight(model);
    }

    Flight? ITabledCrudModule<Flight, int>.Read(int key)
    {
        return m_flightsModule.GetFlight(key);
    }

    IResult ITabledCrudModule<Flight, int>.Update(Flight model)
    {
        return m_flightsModule.UpdateFlight(model);
    }

    IResult ITabledCrudModule<Flight, int>.Destroy(Flight model)
    {
        return m_flightsModule.DeleteFlight(model);
    }

    ICollection<Flight> ITabledCrudModule<Flight, int>.List()
    {
        return m_flightsModule.ListFlights();
    }
}