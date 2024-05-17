using System.Diagnostics;
using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class CityCrudTemplate : GenericCrudTemplate<City, string>
{
    private readonly ILocationsModule m_locationsModule;

    public CityCrudTemplate(ILocationsModule locationsModule) : base(new TabledLocationsModule(locationsModule), "City")
    {
        m_locationsModule = locationsModule;
    }

    public override IIntrospectViewModel CreateItemViewmodel(object model) => new CityIntrospectViewModel(m_locationsModule, (City)model);
}