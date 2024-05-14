using System.Diagnostics;
using System.Windows;
using Autofac;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class AirportCrudTemplate : GenericCrudTemplate<Airport, string>
{
    private readonly ILocationsModule m_locationsModule;

    public AirportCrudTemplate(ILocationsModule locationsModule) : base(new TabledLocationsModule(locationsModule), "Airports")
    {
        m_locationsModule = locationsModule;
    }
    
    public override IIntrospectViewModel CreateItemViewmodel(object model) => new AirportIntrospectViewModel(m_locationsModule, (Airport)model);
}