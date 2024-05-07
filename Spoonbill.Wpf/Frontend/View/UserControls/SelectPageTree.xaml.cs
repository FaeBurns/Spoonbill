using System.Windows;
using System.Windows.Controls;
using Spoonbill.Wpf.Frontend.ViewModels;
using Spoonbill.Wpf.Frontend.ViewModels.PageTree;

namespace Spoonbill.Wpf.Frontend.View.UserControls;

public partial class SelectPageTree : UserControl
{
    public SelectPageTree()
    {
        InitializeComponent();
    }

    private void TreeView_OnSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        PageTreeHostViewModel viewModel = DataContext as PageTreeHostViewModel ?? throw new InvalidCastException();
        PageTreeItemViewModel selectedItem = e.NewValue as PageTreeItemViewModel ?? throw new InvalidCastException();

        viewModel.CurrentControl = selectedItem.ControlBuilder?.Invoke();
    }
}