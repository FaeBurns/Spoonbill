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
        try
        {
            Staff? result = GetStaffWorker(id);
            result ??= GetPilot(id);
            return result;
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateStaff(Staff staff)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Add(staff);
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

    public IResult UpdateStaff(Staff staff)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Update(staff);
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

    public IResult DeleteStaff(Staff staff)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Remove(staff);
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
    public StaffWorker? GetStaffWorker(int id)
    {
        try
        {
            return m_context.StaffWorkers.Find(id);
        }
        catch
        {
            return null;
        }
    }

    [Pure]
    public Pilot? GetPilot(int id)
    {
        try
        {
            return m_context.Pilots.Find(id);
        }
        catch
        {
            return null;
        }
    }

    [Pure]
    public ICollection<Pilot> ListPilots()
    {
        try
        {
            return m_context.Pilots.ToList();
        }
        catch
        {
            return new List<Pilot>();
        }
    }

    [Pure]
    public ICollection<StaffWorker> ListStaffWorkers()
    {
        try
        {
            return m_context.StaffWorkers.ToList();
        }
        catch
        {
            return new List<StaffWorker>();
        }
    }
}
