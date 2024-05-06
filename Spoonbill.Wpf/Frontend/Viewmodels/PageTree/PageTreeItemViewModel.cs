using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Spoonbill.Wpf.Frontend.Viewmodels.PageTree;

public class PageTreeItemViewModel : ViewModel
{
    public PageTreeItemViewModel(string name)
    {
        Name = name;
    }

    public PageTreeItemViewModel(string name, Control? displayControl)
    {
        Name = name;
        DisplayControl = displayControl;
    }

    public ObservableCollection<PageTreeItemViewModel> Children { get; init; } = new ObservableCollection<PageTreeItemViewModel>();
    public Control? DisplayControl { get; }
    public string Name { get; }
}