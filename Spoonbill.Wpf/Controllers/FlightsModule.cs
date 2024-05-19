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
        try
        {
            return m_context.Flights.Find(id);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateFlight(Flight flight)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
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
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
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
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
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
        try
        {
            return m_context.Flights.ToList();
        }
        catch
        {
            return new List<Flight>();
        }
    }
}
