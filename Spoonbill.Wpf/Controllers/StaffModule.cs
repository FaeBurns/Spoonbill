using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class StaffModule : IStaffModule
{
    private readonly SpoonbillContext m_context;

    public StaffModule(SpoonbillContext context)
    {
        m_context = context;
    }

    [Pure]
    public Staff? GetStaff(int id)
    {
        Staff? result = GetStaffWorker(id);
        result ??= GetPilot(id);
        return result;
    }

    public IResult CreateStaff(Staff staff)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Add(staff);
            m_context.SaveChanges();
            transaction.Commit();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
        finally
        {
            m_context.ChangeTracker.Clear();
        }
    }

    public IResult UpdateStaff(Staff staff)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();

        try
        {
            m_context.Update(staff);
            m_context.SaveChanges();
            transaction.Commit();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
        finally
        {
            m_context.ChangeTracker.Clear();
        }
    }

    public IResult DeleteStaff(Staff staff)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();

        try
        {
            m_context.Remove(staff);
            m_context.SaveChanges();
            transaction.Commit();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
        finally
        {
            m_context.ChangeTracker.Clear();
        }
    }

    [Pure]
    public StaffWorker? GetStaffWorker(int id)
    {
        return m_context.StaffWorkers.Find(id);
    }

    [Pure]
    public Pilot? GetPilot(int id)
    {
        return m_context.Pilots.Find(id);
    }

    [Pure]
    public ICollection<Pilot> ListPilots()
    {
        return m_context.Pilots.ToList();
    }

    [Pure]
    public ICollection<StaffWorker> ListStaffWorkers()
    {
        return m_context.StaffWorkers.ToList();
    }
}