using System.Windows;
using Spoonbill.Wpf.Controllers.Tabled;
using Spoonbill.Wpf.Data.Models;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public abstract class GenericCrudTemplate<TModel, TKey> : ICrudTemplate 
    where TModel : class, new()
{
    public ITabledCrudModule<TModel, TKey> CrudModule { get; }

    protected GenericCrudTemplate(ITabledCrudModule<TModel, TKey> crudModule, string templatePrefix)
    {
        CrudModule = crudModule;
        ListTemplate = (DataTemplate)Application.Current.Resources[templatePrefix + "ListItemTemplate"]!;
        IntrospectTemplate = (DataTemplate)Application.Current.Resources[templatePrefix + "IntrospectItemTemplate"]!;
        ListHeaderTemplate = (DataTemplate)Application.Current.Resources[templatePrefix + "ListHeaderTemplate"]!;
    }
    
    public DataTemplate ListTemplate { get; }
    public DataTemplate IntrospectTemplate { get; }
    public DataTemplate ListHeaderTemplate { get; }
    
    public ICollection<object> BuildList()
    {
        return CrudModule.List().Select(o => (object)o).ToList();
    }

    public IResult Save(object model, IntrospectMode mode)
    {
        if (model is not TModel value)
        {
            return new Invalid($"Invalid model type {model.GetType()}");
        }

        switch (mode)
        {
            case IntrospectMode.CREATE:
                return CrudModule.Create(value);
            case IntrospectMode.EDIT:
                return CrudModule.Update(value);
            default:
                return new Invalid("Invalid introspect mode");
        }
    }

    public IResult Delete(object model)
    {
        if (model is not TModel valid)
        {
            return new Invalid($"Invalid model type {model.GetType()}. {typeof(TModel)} expected");
        }
        
        return CrudModule.Destroy(valid);
    }

    public IIntrospectViewModel CreateItemViewmodel() => CreateItemViewmodel(new TModel());
    public abstract IIntrospectViewModel CreateItemViewmodel(object model);
}