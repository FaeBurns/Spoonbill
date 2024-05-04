using Microsoft.EntityFrameworkCore;
using Spoonbill.Wpf.Data;
using Spoonbill.Wpf.Data.Models;

namespace Spoonbill.Tests.Database;

public class LocationTests : DbTest
{
    public const string ValidCountyName = "ValidCounty";
    public const string ValidCityName = "ValidCity";
    public const string ValidAirportName = "ValidAirport";
    public const string ValidCountryName = "ValidCountry";

    [Test]
    public void AddCounty_Valid()
    {
        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        context.Counties.Add(new County()
        {
            Name = ValidCountyName,
            Country = ValidCountryName,
        });
        context.SaveChanges();

        County? county = context.Counties.Find(ValidCountyName);
        Assert.That(county, Is.Not.Null);
        Assert.That(county.Name, Is.EqualTo(ValidCountyName));
        Assert.That(county.Country, Is.Not.Null);
        Assert.That(county.Country, Is.EqualTo(ValidCountryName));
    }

    [Test]
    public void AddCity_Valid()
    {
        AddCounty_Valid();

        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        context.Cities.Add(new City()
        {
            Name = ValidCityName,
            County = context.Counties.Find(ValidCountyName)!,
        });
        context.SaveChanges();

        City? city = context.Cities.Include(c => c.County).First(c => c.Name == ValidCityName);
        Assert.That(city, Is.Not.Null);
        Assert.That(city.Name, Is.EqualTo(ValidCityName));
        Assert.That(city.County, Is.Not.Null);
        Assert.That(city.County, Is.EqualTo(context.Counties.Find(ValidCountyName)));
    }

    [Test]
    public void AddAirport_Valid()
    {
        AddCity_Valid();

        using SpoonbillContext context = new SpoonbillContext(TestSetup.Options);
        context.Airports.Add(new Airport()
        {
            Name = ValidAirportName,
            City = context.Cities.Find(ValidCityName)!,
        });
        context.SaveChanges();

        Airport airport = context.Airports.Include(a => a.City).First(a => a.Name == ValidAirportName);
        Assert.That(airport, Is.Not.Null);
        Assert.That(airport.Name, Is.EqualTo(ValidAirportName));
        Assert.That(airport.City, Is.Not.Null);
        Assert.That(airport.City, Is.EqualTo(context.Cities.Find(ValidCityName)));
    }
}