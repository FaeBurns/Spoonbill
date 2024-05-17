using Microsoft.EntityFrameworkCore.Storage;
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
        return m_context.Flights.Find(id);
    }

    public IResult CreateFlight(Flight flight)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Flights.Add(flight);
            m_context.SaveChanges();
            transaction.Commit();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e);
        }
        finally
        {
            m_context.ChangeTracker.Clear();
        }
    }

    public IResult UpdateFlight(Flight flight)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Flights.Update(flight);
            m_context.SaveChanges();
            transaction.Commit();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e);
        }
        finally
        {
            m_context.ChangeTracker.Clear();
        }
    }

    public IResult DeleteFlight(Flight flight)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Flights.Remove(flight);
            m_context.SaveChanges();
            transaction.Commit();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e);
        }
        finally
        {
            m_context.ChangeTracker.Clear();
        }
    }

    public ICollection<Flight> ListFlights()
    {
        return m_context.Flights.ToList();
    }
}