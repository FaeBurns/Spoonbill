using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class PassengerCrudTemplate : ICrudTemplate
{
    private readonly IPassengerModule m_passengerModule;

    public PassengerCrudTemplate(IPassengerModule passengerModule)
    {
        m_passengerModule = passengerModule;
    }

    public DataTemplate ListTemplate => (DataTemplate)Application.Current.Resources["PassengersListItemTemplate"]!;
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources["PassengersIntrospectItemTemplate"]!;
    public DataTemplate ListHeaderTemplate => (DataTemplate)Application.Current.Resources["PassengersListHeaderTemplate"]!;

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
}