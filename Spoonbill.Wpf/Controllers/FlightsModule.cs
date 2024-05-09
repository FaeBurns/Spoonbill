using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class FlightsModule : IFlightsModule
{
    private readonly SpoonbillContext m_context;

    public FlightsModule(SpoonbillContext context)
    {
        m_context = context;
    }

    public Flight? GetFlight(int id)
    {
        // kinda hate how big this is but there isn't an easy fix for it
        return m_context.Flights.Find(id);
    }

    public IResult CreateFlight(Flight flight)
    {
        try
        {
            m_context.Flights.Add(flight);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateFlight(Flight flight)
    {
        try
        {
            m_context.Flights.Update(flight);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteFlight(Flight flight)
    {
        try
        {
            m_context.Flights.Remove(flight);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<Flight> ListFlights()
    {
        return m_context.Flights.ToList();
    }
}