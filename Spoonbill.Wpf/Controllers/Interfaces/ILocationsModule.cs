using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Controllers.Interfaces;

public interface ILocationsModule
{
    County? GetCounty(string name);
    IResult CreateCounty(County county);
    IResult UpdateCounty(County county);
    IResult DeleteCounty(County county);
    ICollection<County> ListCounties();
    City? GetCity(string name);
    IResult CreateCity(City city);
    IResult UpdateCity(City city);
    IResult DeleteCity(City city);
    ICollection<City> ListCities();
    Airport? GetAirport(string name);
    IResult CreateAirport(Airport airport);
    IResult UpdateAirport(Airport airport);
    IResult DeleteAirport(Airport airport);
    ICollection<Airport> ListAirports();
}