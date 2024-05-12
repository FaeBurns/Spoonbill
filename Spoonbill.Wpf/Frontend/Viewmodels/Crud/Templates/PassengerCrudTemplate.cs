using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class PassengerCrudTemplate : ICrudTemplate
{
    private const string TEMPLATE_PREFIX = "Passengers";

    private readonly IPassengerModule m_passengerModule;
    private readonly IFlightsModule m_flightsModule;

    public PassengerCrudTemplate(IPassengerModule passengerModule, IFlightsModule flightsModule)
    {
        m_passengerModule = passengerModule;
        m_flightsModule = flightsModule;
    }

    public DataTemplate ListTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListItemTemplate"]!;
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "IntrospectItemTemplate"]!;
    public DataTemplate ListHeaderTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListHeaderTemplate"]!;

    public ICollection<object> BuildList()
    {
        return m_passengerModule.ListPassengers().Select(p => (object)p).ToList();
    }

    public IResult Save(object model, IntrospectMode mode)
    {
        if (mode is not (IntrospectMode.EDIT or IntrospectMode.CREATE))
            return new Invalid("Invalid introspect mode");

        if (model is not Passenger passenger)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        switch (mode)
        {
            case IntrospectMode.EDIT:
                return m_passengerModule.UpdatePassenger(passenger);
            case IntrospectMode.CREATE:
                return m_passengerModule.CreatePassenger(passenger);
        }

        throw new UnreachableException();
    }

    public IResult Delete(object model)
    {
        if (model is not Passenger passenger)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        return m_passengerModule.DeletePassenger(passenger);
    }

    public IIntrospectViewModel CreateItemViewmodel() => CreateItemViewmodel(new Passenger());
    public IIntrospectViewModel CreateItemViewmodel(object model) => new PassengerIntrospectViewModel(m_flightsModule, (Passenger)model);
}