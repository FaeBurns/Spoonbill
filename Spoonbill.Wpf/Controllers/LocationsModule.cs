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
        return m_context.Counties.Find(name);
    }

    public IResult CreateCounty(County county)
    {
        try
        {
            m_context.Counties.Add(county);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateCounty(County county)
    {
        try
        {
            m_context.Counties.Update(county);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteCounty(County county)
    {
        try
        {
            m_context.Counties.Remove(county);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<County> ListCounties()
    {
        return m_context.Counties.ToList();
    }

    public City? GetCity(string name)
    {
        return m_context.Cities.Find(name);
    }

    public IResult CreateCity(City city)
    {
        try
        {
            m_context.Cities.Add(city);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateCity(City city)
    {
        try
        {
            m_context.Cities.Update(city);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteCity(City city)
    {
        try
        {
            m_context.Cities.Remove(city);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<City> ListCities()
    {
        return m_context.Cities.ToList();
    }

    public Airport? GetAirport(string name)
    {
        return m_context.Airports.Find(name);
    }

    public IResult CreateAirport(Airport airport)
    {
        try
        {
            m_context.Airports.Add(airport);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult UpdateAirport(Airport airport)
    {
        try
        {
            m_context.Airports.Update(airport);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public IResult DeleteAirport(Airport airport)
    {
        try
        {
            m_context.Airports.Remove(airport);
            m_context.SaveChanges();
            return new Ok();
        }
        catch (Exception e)
        {
            return new Error(e.Message);
        }
    }

    public ICollection<Airport> ListAirports()
    {
        return m_context.Airports.ToList();
    }
}