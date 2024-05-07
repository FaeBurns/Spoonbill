using System.Collections.ObjectModel;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudHostViewModel : ViewModel
{
    public CrudHostViewModel()
    {
        
    }

    public StatusIndicator StatusIndicator { get; } = new StatusIndicator();

    public ObservableCollection<CrudListItemViewModel> Entries { get; } = new ObservableCollection<CrudListItemViewModel>();

    public CrudIntrospectItemViewModel? SelectedItem { get; } = null;
}