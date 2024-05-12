using System.Diagnostics;
using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class CityCrudTemplate : ICrudTemplate
{
    private const string TEMPLATE_PREFIX = "City";
    private readonly ILocationsModule m_locationsModule;
    public DataTemplate ListTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListItemTemplate"]!;
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "IntrospectItemTemplate"]!;
    public DataTemplate ListHeaderTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListHeaderTemplate"]!;

    public CityCrudTemplate(ILocationsModule locationsModule)
    {
        m_locationsModule = locationsModule;
    }

    public ICollection<object> BuildList()
    {
        return m_locationsModule.ListCities().Select(c => (object)c).ToList();
    }

    public IResult Save(object model, IntrospectMode mode)
    {
        if (mode is not (IntrospectMode.EDIT or IntrospectMode.CREATE))
            return new Invalid("Invalid introspect mode");

        if (model is not City city)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        switch (mode)
        {
            case IntrospectMode.EDIT:
                return m_locationsModule.UpdateCity(city);
            case IntrospectMode.CREATE:
                return m_locationsModule.CreateCity(city);
        }

        throw new UnreachableException();
    }

    public IResult Delete(object model)
    {
        if (model is not City city)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        return m_locationsModule.DeleteCity(city);
    }

    public IIntrospectViewModel CreateItemViewmodel() => CreateItemViewmodel(new City());

    public IIntrospectViewModel CreateItemViewmodel(object model) => new CityIntrospectViewModel(m_locationsModule, (City)model);
}