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
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources["PassengersEditItemTemplate"]!;

    public ICollection<CrudListItemViewModel> BuildList()
    {
        List<CrudListItemViewModel> result = new List<CrudListItemViewModel>();
        foreach (Passenger passenger in m_passengerModule.ListPassengers())
        {
            result.Add(new CrudListItemViewModel(passenger));
        }
    }

    public CrudIntrospectItemViewModel ConvertIntrospect(CrudListItemViewModel item)
    {
        Passenger passenger = (Passenger)item.CrudObject;
        return new CrudIntrospectItemViewModel(m_passengerModule.GetPassenger())
    }
}