using System.Diagnostics.Contracts;
using Microsoft.EntityFrameworkCore.Storage;
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
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Planes.Add(plane);
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

    public IResult UpdatePlane(Plane plane)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Planes.Update(plane);
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

    public IResult DeletePlane(Plane plane)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Planes.Remove(plane);
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
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.PlaneModels.Add(model);
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

    public IResult UpdateModel(PlaneModel model)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.PlaneModels.Update(model);
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

    public IResult DeleteModel(PlaneModel model)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.PlaneModels.Remove(model);
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
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Manufacturers.Add(manufacturer);
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

    public IResult UpdateManufacturer(Manufacturer manufacturer)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Manufacturers.Update(manufacturer);
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

    public IResult DeleteManufacturer(Manufacturer manufacturer)
    {
        using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
        try
        {
            m_context.Manufacturers.Remove(manufacturer);
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

    public ICollection<Manufacturer> ListManufacturers()
    {
        return m_context.Manufacturers.ToList();
    }
}