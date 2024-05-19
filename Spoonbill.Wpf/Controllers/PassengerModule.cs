using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class PassengerModule : IPassengerModule
{
    private readonly SpoonbillContext m_context;

    public PassengerModule(SpoonbillContext context)
    {
        m_context = context;
    }

    [Pure]
    public Passenger? GetPassenger(int id)
    {
        try
        {
            return m_context.Passengers.Find(id);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreatePassenger(Passenger passenger)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Passengers.Add(passenger);
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

    public IResult UpdatePassenger(Passenger passenger)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Passengers.Update(passenger);
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

    public IResult DeletePassenger(Passenger passenger)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Passengers.Remove(passenger);
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

    [Pure]
    public ICollection<Passenger> ListPassengers()
    {
        try
        {
            return m_context.Passengers.ToList();
        }
        catch
        {
            return new List<Passenger>();
        }
    }
}
