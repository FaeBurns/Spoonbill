using Microsoft.EntityFrameworkCore.Storage;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers;

public class LocationsModule : ILocationsModule
{
    private readonly SpoonbillContext m_context;

    public LocationsModule(SpoonbillContext context)
    {
        m_context = context;
    }

    public County? GetCounty(string name)
    {
        try
        {
            return m_context.Counties.Find(name);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateCounty(County county)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Counties.Add(county);
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

    public IResult UpdateCounty(County county)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Counties.Update(county);
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

    public IResult DeleteCounty(County county)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Counties.Remove(county);
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

    public ICollection<County> ListCounties()
    {
        try
        {
            return m_context.Counties.ToList();
        }
        catch
        {
            return new List<County>();
        }
    }

    public City? GetCity(string name)
    {
        try
        {
            return m_context.Cities.Find(name);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateCity(City city)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Cities.Add(city);
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

    public IResult UpdateCity(City city)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Cities.Update(city);
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

    public IResult DeleteCity(City city)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Cities.Remove(city);
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

    public ICollection<City> ListCities()
    {
        try
        {
            return m_context.Cities.ToList();
        }
        catch
        {
            return new List<City>();
        }
    }

    public Airport? GetAirport(string name)
    {
        try
        {
            return m_context.Airports.Find(name);
        }
        catch
        {
            return null;
        }
    }

    public IResult CreateAirport(Airport airport)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Airports.Add(airport);
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

    public IResult UpdateAirport(Airport airport)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Airports.Update(airport);
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

    public IResult DeleteAirport(Airport airport)
    {
        try
        {
            using IDbContextTransaction transaction = m_context.Database.BeginTransaction();
            m_context.Airports.Remove(airport);
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

    public ICollection<Airport> ListAirports()
    {
        try
        {
            return m_context.Airports.ToList();
        }
        catch
        {
            return new List<Airport>();
        }
    }
}
