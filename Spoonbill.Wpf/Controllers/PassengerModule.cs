using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class PassengerModule
{
    private readonly SpoonbillContext m_context;

    public PassengerModule(SpoonbillContext context)
    {
        m_context = context;
    }

    public Passenger? GetPassenger(int id)
    {
        return m_context.Passengers.Include(p => p.Flights).First(p => p.Id == id);
    }

    public IResult CreatePassenger(Passenger passenger)
    {
        try
        {
            m_context.Passengers.Add(passenger);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdatePassenger(Passenger passenger)
    {
        try
        {
            m_context.Passengers.Update(passenger);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeletePassenger(Passenger passenger)
    {
        try
        {
            m_context.Passengers.Remove(passenger);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }
}