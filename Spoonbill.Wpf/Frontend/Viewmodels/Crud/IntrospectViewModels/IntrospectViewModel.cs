using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public abstract class IntrospectViewModel<T> : ViewModel, IIntrospectViewModel
{
    public object ObjectModel => Model!;
    protected T Model { get; }

    public IntrospectViewModel(T model)
    {
        Model = model;
    }

    public abstract IResult Apply();
}