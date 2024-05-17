using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Tabled;

public class TabledLocationsModule : ITabledCrudModule<City, string>, ITabledCrudModule<County, string>, ITabledCrudModule<Airport, string>
{
    private readonly ILocationsModule m_locationsModule;

    public TabledLocationsModule(ILocationsModule locationsModule)
    {
        m_locationsModule = locationsModule;
    }
    
    public IResult Create(City model)
    {
        return m_locationsModule.CreateCity(model);
    }

    public IResult Create(County model)
    {
        return m_locationsModule.CreateCounty(model);
    }

    public IResult Create(Airport model)
    {
        return m_locationsModule.CreateAirport(model);
    }

    Airport? ITabledCrudModule<Airport, string>.Read(string key)
    {
        return m_locationsModule.GetAirport(key);
    }

    public IResult Update(Airport model)
    {
        return m_locationsModule.UpdateAirport(model);
    }

    public IResult Destroy(Airport model)
    {
        return m_locationsModule.DeleteAirport(model);
    }

    ICollection<Airport> ITabledCrudModule<Airport, string>.List()
    {
        return m_locationsModule.ListAirports();
    }

    County? ITabledCrudModule<County, string>.Read(string key)
    {
        return m_locationsModule.GetCounty(key);
    }

    public IResult Update(County model)
    {
        return m_locationsModule.UpdateCounty(model);
    }

    public IResult Destroy(County model)
    {
        return m_locationsModule.DeleteCounty(model);
    }

    ICollection<County> ITabledCrudModule<County, string>.List()
    {
        return m_locationsModule.ListCounties();
    }

    City? ITabledCrudModule<City, string>.Read(string key)
    {
        return m_locationsModule.GetCity(key);
    }

    public IResult Update(City model)
    {
        return m_locationsModule.UpdateCity(model);
    }

    public IResult Destroy(City model)
    {
        return m_locationsModule.DeleteCity(model);
    }

    ICollection<City> ITabledCrudModule<City, string>.List()
    {
        return m_locationsModule.ListCities();
    }
}