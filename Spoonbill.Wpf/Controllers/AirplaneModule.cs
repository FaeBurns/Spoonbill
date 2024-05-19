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
        try
        {
            return m_context.Planes.Find(serial);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreatePlane(Plane plane)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Planes.Add(plane);
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

    public IResult UpdatePlane(Plane plane)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Planes.Update(plane);
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

    public IResult DeletePlane(Plane plane)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Planes.Remove(plane);
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
    public ICollection<Plane> ListPlanes()
    {
        try
        {
            return m_context.Planes.ToList();
        }
        catch
        {
            return new List<Plane>();
        }
    }

    [Pure]
    public PlaneModel? GetModel(int modelNumber)
    {
        try
        {
            return m_context.PlaneModels.Find(modelNumber);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateModel(PlaneModel model)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.PlaneModels.Add(model);
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

    public IResult UpdateModel(PlaneModel model)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.PlaneModels.Update(model);
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

    public IResult DeleteModel(PlaneModel model)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.PlaneModels.Remove(model);
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

    public ICollection<PlaneModel> ListModels()
    {
        try
        {
            return m_context.PlaneModels.ToList();
        }
        catch
        {
            return new List<PlaneModel>();
        }
    }

    public Manufacturer? GetManufacturer(string name)
    {
        try
        {
            return m_context.Manufacturers.Find(name);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateManufacturer(Manufacturer manufacturer)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Manufacturers.Add(manufacturer);
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

    public IResult UpdateManufacturer(Manufacturer manufacturer)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Manufacturers.Update(manufacturer);
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

    public IResult DeleteManufacturer(Manufacturer manufacturer)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Manufacturers.Remove(manufacturer);
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

    public ICollection<Manufacturer> ListManufacturers()
    {
        try
        {
            return m_context.Manufacturers.ToList();
        }
        catch
        {
            return new List<Manufacturer>();
        }
    }
}
