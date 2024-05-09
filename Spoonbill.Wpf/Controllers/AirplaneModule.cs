using System.Diagnostics.Contracts;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class AirplaneModule : IAirplaneModule
{
    private readonly SpoonbillContext m_context;

    public AirplaneModule(SpoonbillContext context)
    {
        m_context = context;
    }

    [Pure]
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

    [Pure]
    public ICollection<Plane> ListPlanes()
    {
        return m_context.Planes.ToList();
    }

    [Pure]
    public PlaneModel? GetModel(int modelNumber)
    {
        return m_context.PlaneModels.Find(modelNumber);
    }

    public IResult CreateModel(PlaneModel model)
    {
        try
        {
            m_context.PlaneModels.Add(model);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateModel(PlaneModel model)
    {
        try
        {
            m_context.PlaneModels.Update(model);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteModel(PlaneModel model)
    {
        try
        {
            m_context.PlaneModels.Remove(model);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<PlaneModel> ListModels()
    {
        return m_context.PlaneModels.ToList();
    }

    public Manufacturer? GetManufacturer(string name)
    {
        return m_context.Manufacturers.Find(name);
    }

    public IResult CreateManufacturer(Manufacturer manufacturer)
    {
        try
        {
            m_context.Manufacturers.Add(manufacturer);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateManufacturer(Manufacturer manufacturer)
    {
        try
        {
            m_context.Manufacturers.Update(manufacturer);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteManufacturer(Manufacturer manufacturer)
    {
        try
        {
            m_context.Manufacturers.Remove(manufacturer);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<Manufacturer> ListManufacturers()
    {
        return m_context.Manufacturers.ToList();
    }
}