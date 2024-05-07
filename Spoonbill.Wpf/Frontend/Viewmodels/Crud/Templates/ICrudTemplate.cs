using System.Windows;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

public interface ICrudTemplate
{
    public DataTemplate ListTemplate { get; }
    public DataTemplate IntrospectTemplate { get; }

    public ICollection<CrudListItemViewModel> BuildList();
    public CrudIntrospectItemViewModel ConvertIntrospect(CrudListItemViewModel item);
}