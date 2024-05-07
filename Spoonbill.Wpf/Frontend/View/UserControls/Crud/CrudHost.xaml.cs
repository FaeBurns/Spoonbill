using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;

namespace Spoonbill.Wpf.Frontend.View.UserControls.Crud;

public partial class CrudHost : UserControl
{
    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty ListItemTemplateProperty = DependencyProperty.Register(
        nameof(ListItemTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty EditTemplateProperty = DependencyProperty.Register(
        nameof(EditTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));
    
    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty ReadTemplateProperty = DependencyProperty.Register(
        nameof(ReadTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));
    
    public DataTemplate ListItemTemplate
    {
        get => (DataTemplate)GetValue(ListItemTemplateProperty);
        init => SetValue(ListItemTemplateProperty, value);
    }

    public DataTemplate EditTemplate
    {
        get => (DataTemplate)GetValue(EditTemplateProperty);
        init => SetValue(EditTemplateProperty, value);
    }

    public DataTemplate ReadTemplate
    {
        get => (DataTemplate)GetValue(ReadTemplateProperty);
        init => SetValue(ReadTemplateProperty, value);
    }

    public CrudHost(DataTemplate listTemplate, DataTemplate editTemplate, DataTemplate readTemplate)
    {
        ListItemTemplate = listTemplate;
        EditTemplate = editTemplate;
        ReadTemplate = readTemplate;
        InitializeComponent();
    }
}