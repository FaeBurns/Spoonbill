using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class CityIntrospectViewModel : IntrospectViewModel<City>
{
    private readonly ILocationsModule m_locationsModule;
    public string Name { get; set; }
    public string County { get; set; }

    public LazyLoadViewModel<IEnumerable<string>> AvailableCounties { get; }

    public CityIntrospectViewModel(ILocationsModule locationsModule, City model) : base(model)
    {
        m_locationsModule = locationsModule;
        Name = model.Name;
        County = model.County?.Name ?? String.Empty;
        AvailableCounties = new LazyLoadViewModel<IEnumerable<string>>(() => locationsModule.ListCounties().Select(c => c.Name));
    }

    public override IResult Apply()
    {
        County? targetCounty = m_locationsModule.GetCounty(County);
        if (targetCounty == null)
            return new Invalid($"Target county {County} is not present in database");

        if (String.IsNullOrEmpty(Name))
            return new Invalid("City name must not be empty");

        Model.Name = Name;
        Model.County = targetCounty;

        return new Ok();
    }
}