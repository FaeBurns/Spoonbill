using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace Spoonbill.Wpf.Frontend.ViewModels.PageTree;

public class PageTreeHostViewModel : ViewModel
{
    private Control? m_currentControl = null;
    public ObservableCollection<PageTreeItemViewModel> Items { get; init; } = new ObservableCollection<PageTreeItemViewModel>();

    public Control? CurrentControl
    {
        get => m_currentControl;
        set => SetField(ref m_currentControl, value);
    }
}