using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class StaffModule
{
    private readonly SpoonbillContext m_context;

    public StaffModule(SpoonbillContext context)
    {
        m_context = context;
    }

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

    public StaffWorker? GetStaffWorker(int id)
    {
        return m_context.StaffWorkers.Include(s => s.AssignedFlights).First(s => s.Id == id);
    }

    public Pilot? GetPilot(int id)
    {
        return m_context.Pilots.Include(p => p.AssignedFlights).First(p => p.Id == id);
    }
}