using System.Diagnostics.Contracts;
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
        try
        {
            m_context.Add(staff);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateStaff(Staff staff)
    {
        try
        {
            m_context.Update(staff);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteStaff(Staff staff)
    {
        try
        {
            m_context.Remove(staff);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
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
    public ICollection<Staff> ListStaff()
    {
        List<Staff> result = new List<Staff>(m_context.StaffWorkers);
        result.AddRange(m_context.Pilots);
        return result;
    }
}