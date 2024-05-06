using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Spoonbill.Wpf.Frontend.Viewmodels.PageTree;

public class PageTreeItemViewModel : ViewModel
{
    public PageTreeItemViewModel(string name)
    {
        Name = name;
    }

    public PageTreeItemViewModel(string name, Func<Control>? controlBuilder)
    {
        Name = name;
        ControlBuilder = controlBuilder;
    }

    public ObservableCollection<PageTreeItemViewModel> Children { get; init; } = new ObservableCollection<PageTreeItemViewModel>();
    public Func<Control>? ControlBuilder { get; init; }
    public string Name { get; }
}