using System.Diagnostics;
using System.Windows;
using Spoonbill.Wpf.Controllers.Interfaces;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public class CountyCrudTemplate : ICrudTemplate
{
    private const string TEMPLATE_PREFIX = "County";
    private readonly ILocationsModule m_locationsModule;
    public DataTemplate ListTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListItemTemplate"]!;
    public DataTemplate IntrospectTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "IntrospectItemTemplate"]!;
    public DataTemplate ListHeaderTemplate => (DataTemplate)Application.Current.Resources[TEMPLATE_PREFIX + "ListHeaderTemplate"]!;

    public CountyCrudTemplate(ILocationsModule locationsModule)
    {
        m_locationsModule = locationsModule;
    }

    public ICollection<object> BuildList()
    {
        return m_locationsModule.ListCounties().Select(c => (object)c).ToList();
    }

    public IResult Save(object model, IntrospectMode mode)
    {
        if (mode is not (IntrospectMode.EDIT or IntrospectMode.CREATE))
            return new Invalid("Invalid introspect mode");

        if (model is not County county)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        switch (mode)
        {
            case IntrospectMode.EDIT:
                return m_locationsModule.UpdateCounty(county);
            case IntrospectMode.CREATE:
                return m_locationsModule.CreateCounty(county);
        }

        throw new UnreachableException();
    }

    public IResult Delete(object model)
    {
        if (model is not County county)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        return m_locationsModule.DeleteCounty(county);
    }

    public IIntrospectViewModel CreateItemViewmodel() => CreateItemViewmodel(new County());

    public IIntrospectViewModel CreateItemViewmodel(object model) => new CountyIntrospectViewModel((County)model);
}