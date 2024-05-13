using System.Diagnostics;
using System.Windows;
using Autofac;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class AirportCrudTemplate : ICrudTemplate
{
    private const string TEMPLATE_PREFIX = "Airports";
    private readonly ILocationsModule m_locationsModule;

    public AirportCrudTemplate(ILocationsModule locationsModule)
    {
        m_locationsModule = locationsModule;
    }

    public DataTemplate ListTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListItemTemplate"]!;
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "IntrospectItemTemplate"]!;
    public DataTemplate ListHeaderTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListHeaderTemplate"]!;

    public ICollection<object> BuildList()
    {
        return m_locationsModule.ListAirports().Select(a => (object)a).ToList();
    }

    public IResult Save(object model, IntrospectMode mode)
    {
        if (mode is not (IntrospectMode.EDIT or IntrospectMode.CREATE))
            return new Invalid("Invalid introspect mode");

        if (model is not Airport airport)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        switch (mode)
        {
            case IntrospectMode.EDIT:
                return m_locationsModule.UpdateAirport(airport);
            case IntrospectMode.CREATE:
                return m_locationsModule.CreateAirport(airport);
        }

        throw new UnreachableException();
    }

    public IResult Delete(object model)
    {
        if (model is not Airport airport)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        return m_locationsModule.DeleteAirport(airport);
    }

    public IIntrospectViewModel CreateItemViewmodel() => CreateItemViewmodel(new Airport());

    public IIntrospectViewModel CreateItemViewmodel(object model) => new AirportIntrospectViewModel(m_locationsModule, (Airport)model);
}