using System.Collections.ObjectModel;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudHostViewModel : ViewModel
{
    public StatusIndicator StatusIndicator { get; } = new StatusIndicator();
    
    public ObservableCollection<CrudItemViewModel> Entries { get; } = new ObservableCollection<CrudItemViewModel>();
}