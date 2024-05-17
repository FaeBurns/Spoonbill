using JetBrains.Annotations;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

[UsedImplicitly(ImplicitUseKindFlags.Access, ImplicitUseTargetFlags.Members | ImplicitUseTargetFlags.WithInheritors)]
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