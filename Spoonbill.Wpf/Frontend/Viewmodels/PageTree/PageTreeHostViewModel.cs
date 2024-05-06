using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Spoonbill.Wpf.Frontend.Viewmodels.PageTree;

public class PageTreeHostViewModel
{
    public ObservableCollection<PageTreeItemViewModel> Items { get; init; } = new ObservableCollection<PageTreeItemViewModel>();
    public Control? CurrentControl { get; set; } = null;
}