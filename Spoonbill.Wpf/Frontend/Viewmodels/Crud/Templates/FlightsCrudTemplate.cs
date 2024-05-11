using System.Diagnostics;
using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class FlightsCrudTemplate : ICrudTemplate
{
    private readonly IPassengerModule m_passengersModule;
    private readonly IFlightsModule m_flightsModule;

    public FlightsCrudTemplate(ISpoonbillContainer container)
    {
        m_passengersModule = container.PassengerModule;
        m_flightsModule = container.FlightsModule;
    }

    public DataTemplate ListTemplate => (DataTemplate)Application.Current.Resources["FlightsListItemTemplate"]!;
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources["FlightsIntrospectItemTemplate"]!;
    public DataTemplate ListHeaderTemplate => (DataTemplate)Application.Current.Resources["FlightsListHeaderTemplate"]!;

    public ICollection<object> BuildList()
    {
        return m_flightsModule.ListFlights().Select(f => (object)f).ToList();
    }

    public IResult Save(object model, IntrospectMode mode)
    {
        if (mode is not (IntrospectMode.EDIT or IntrospectMode.CREATE))
            return new Invalid("Invalid introspect mode");

        if (model is not Flight flight)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        switch (mode)
        {
            case IntrospectMode.EDIT:
                return m_flightsModule.UpdateFlight(flight);
            case IntrospectMode.CREATE:
                return m_flightsModule.CreateFlight(flight);
        }

        throw new UnreachableException();
    }

    public IResult Delete(object model)
    {
        if (model is not Flight flight)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        return m_flightsModule.DeleteFlight(flight);
    }

    public IIntrospectViewModel CreateItemViewmodel() => CreateItemViewmodel(new Flight());
    public IIntrospectViewModel CreateItemViewmodel(object model) => new FlightIntrospectViewModel(m_flightsModule, m_passengersModule, (Flight)model);
}