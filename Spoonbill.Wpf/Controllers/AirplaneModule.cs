using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class AirplaneModule
{
    private readonly SpoonbillContext m_context;

    public AirplaneModule(SpoonbillContext context)
    {
        m_context = context;
    }

    public Plane? GetPlane(string serial)
    {
        return m_context.Planes.Find(serial);
    }

    public IResult CreatePlane(Plane plane)
    {
        try
        {
            m_context.Planes.Add(plane);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdatePlane(Plane plane)
    {
        try
        {
            m_context.Planes.Update(plane);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeletePlane(Plane plane)
    {
        try
        {
            m_context.Planes.Remove(plane);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<Plane> ListPlanes()
    {
        return m_context.Planes.ToList();
    }
}