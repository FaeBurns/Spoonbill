using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;

public interface IIntrospectViewModel
{
    public object ObjectModel { get; }

    public IResult Apply();
}