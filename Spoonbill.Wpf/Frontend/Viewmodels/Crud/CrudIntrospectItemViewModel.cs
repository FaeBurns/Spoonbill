using System.Windows.Input;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudIntrospectItemViewModel
{
    public CrudIntrospectItemViewModel(object crudObject, bool isReadOnly, ICommand saveCommand)
    {
        CrudObject = crudObject;
        IsReadOnly = isReadOnly;
        SaveCommand = saveCommand;
    }

    public object CrudObject { get; }
    public bool IsReadOnly { get; }
    public ICommand SaveCommand { get; }
}