using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using Spoonbill.Wpf.Frontend.Builders;
using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.View.UserControls.Crud;

public partial class CrudHost : UserControl
{
    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty ListItemTemplateProperty = DependencyProperty.Register(
        nameof(ListItemTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty IntrospectTemplateProperty = DependencyProperty.Register(
        nameof(IntrospectTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));

    public DataTemplate ListItemTemplate
    {
        get => (DataTemplate)GetValue(ListItemTemplateProperty);
        init => SetValue(ListItemTemplateProperty, value);
    }

    public DataTemplate IntrospectTemplate
    {
        get => (DataTemplate)GetValue(IntrospectTemplateProperty);
        init => SetValue(IntrospectTemplateProperty, value);
    }

    public CrudHost(ICrudTemplate template)
    {
        ListItemTemplate = template.ListTemplate;
        IntrospectTemplate = template.IntrospectTemplate;
        InitializeComponent();
        CrudHostViewModel viewModel = new CrudHostViewModel(template);
        DataContext = viewModel;
    }
}