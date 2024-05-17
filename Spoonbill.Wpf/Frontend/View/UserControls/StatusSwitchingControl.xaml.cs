using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using Spoonbill.Wpf.Frontend.ViewModels;

namespace Spoonbill.Wpf.Frontend.View.UserControls;

public partial class StatusSwitchingControl : UserControl
{
    /// <inheritdoc cref="OnLoadedTemplate" />
    [XamlOneWayBindingModeByDefault] public static readonly DependencyProperty OnLoadedTemplateProperty =
        DependencyProperty.Register(
            nameof(OnLoadedTemplate), typeof(DataTemplate), typeof(StatusSwitchingControl),
            new PropertyMetadata(default(DataTemplate)));

    public static readonly DependencyProperty StatusProperty =
        DependencyProperty.Register(
            nameof(Status), typeof(bool), typeof(StatusSwitchingControl),
            new PropertyMetadata(default(bool)));

    /// <inheritdoc cref="LoadingTemplate" />
    [XamlOneWayBindingModeByDefault] public static readonly DependencyProperty LoadingTemplateProperty =
        DependencyProperty.Register(
            nameof(LoadingTemplate), typeof(DataTemplate), typeof(StatusSwitchingControl),
            new PropertyMetadata(Application.Current.Resources["DefaultLoadAwaitingDataTemplate"]));

    public StatusSwitchingControl()
    {
        InitializeComponent();
    }

    /// <summary>
    /// The template to use once the content has loaded.
    /// </summary>
    public DataTemplate OnLoadedTemplate
    {
        get => (DataTemplate)GetValue(OnLoadedTemplateProperty);
        set => SetValue(OnLoadedTemplateProperty, value);
    }

    /// <summary>
    /// The template to use before the content has loaded.
    /// </summary>
    public DataTemplate LoadingTemplate
    {
        get => (DataTemplate)GetValue(LoadingTemplateProperty);
        set => SetValue(LoadingTemplateProperty, value);
    }

    public bool Status
    {
        get => (bool)GetValue(StatusProperty);
        set => SetValue(StatusProperty, value);
    }
}