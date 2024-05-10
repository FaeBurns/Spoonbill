using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.View.UserControls.Crud;

public partial class CrudHost : UserControl, INotifyPropertyChanged
{
    private CrudHostViewModel m_dataModel = null!;

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty ListItemTemplateProperty = DependencyProperty.Register(
        nameof(ListItemTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty IntrospectTemplateProperty = DependencyProperty.Register(
        nameof(IntrospectTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty ListHeaderTemplateProperty = DependencyProperty.Register(
        nameof(ListHeaderTemplate), typeof(DataTemplate), typeof(CrudHost), new PropertyMetadata(default(DataTemplate)));

    public CrudHost(ICrudTemplate template)
    {
        ListItemTemplate = template.ListTemplate;
        IntrospectTemplate = template.IntrospectTemplate;
        ListHeaderTemplate = template.ListHeaderTemplate;
        DataModel = new CrudHostViewModel(template);
        InitializeComponent();
    }

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

    public DataTemplate ListHeaderTemplate
    {
        get => (DataTemplate)GetValue(ListHeaderTemplateProperty);
        init => SetValue(ListHeaderTemplateProperty, value);
    }

    public CrudHostViewModel DataModel
    {
        get => m_dataModel;
        set => SetField(ref m_dataModel, value);
    }
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}