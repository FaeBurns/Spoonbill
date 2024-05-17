using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Spoonbill.Wpf.Frontend.ViewModels;
using Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

namespace Spoonbill.Wpf.Frontend.Commands;

public class RefreshComboBoxCommand : SimpleCommand
{
    public override void Execute(object? parameter)
    {
        ComboBox? comboBox = (parameter as RoutedEventArgs)?.Source as ComboBox;
        if (comboBox == null)
            throw new ArgumentException($"{nameof(RefreshComboBoxCommand)} Expects a routeded event with a {nameof(ComboBox)} source");

        ViewModel? dataContext = comboBox.DataContext as ViewModel;
        if (dataContext == null)
            return;

        comboBox.GetBindingExpression(ComboBox.SelectedItemProperty).UpdateTarget();

        dataContext.RefreshAll();
    }
}