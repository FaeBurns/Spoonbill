using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class AirportIntrospectViewModel : IntrospectViewModel<Airport>
{
    private readonly ILocationsModule m_locationsModule;

    public string Name { get; set; }
    public string City { get; set; }

    public LazyLoadViewModel<IEnumerable<string>> AvailableCities { get; }

    public AirportIntrospectViewModel(ILocationsModule locationsModule, Airport model) : base(model)
    {
        m_locationsModule = locationsModule;
        Name = model.Name ?? String.Empty;
        City = model.City?.Name ?? String.Empty;

        AvailableCities = new LazyLoadViewModel<IEnumerable<string>>(() => locationsModule.ListCities().Select(c => c.Name));
    }

    public override IResult Apply()
    {
        City? targetCity = m_locationsModule.GetCity(City);
        if (targetCity == null)
            return new Invalid($"Target city {City} is not present in database");

        Model.Name = Name;
        Model.City = targetCity;

        return new Ok();
    }
}