using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public class CountyIntrospectViewModel : IntrospectViewModel<County>
{
    public string Name { get; set; }
    public string Country { get; set; }

    public CountyIntrospectViewModel(County model) : base(model)
    {
        Country = model.Country ?? String.Empty;
        Name = model.Name ?? String.Empty;
    }

    public override IResult Apply()
    {
        if (String.IsNullOrEmpty(Name))
            return new Invalid("County name must not be empty");

        if (String.IsNullOrEmpty(Country))
            return new Invalid("Country name must not be empty");

        Model.Name = Name;
        Model.Country = Country;

        return new Ok();
    }
}