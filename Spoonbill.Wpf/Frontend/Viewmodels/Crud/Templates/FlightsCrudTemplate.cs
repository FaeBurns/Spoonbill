using System.Diagnostics;
using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class FlightsCrudTemplate : GenericCrudTemplate<ITabledCrudModule<Flight, int>, Flight, int>
{
    private readonly ISpoonbillContainer m_container;

    public FlightsCrudTemplate(ISpoonbillContainer container) : base(new TabledFlightsModule(container.FlightsModule), "Flights")
    {
        m_container = container;
    }
    
    public override IIntrospectViewModel CreateItemViewmodel(object model) => new FlightIntrospectViewModel(m_container, (Flight)model);
}