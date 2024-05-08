using System.Windows;
using System.Windows.Controls;
using JetBrains.Annotations;
using Spoonbill.Wpf.Frontend.ViewModels;

namespace Spoonbill.Wpf.Frontend.View.UserControls;

public partial class LoadAwaitingControl : UserControl
{
    /// <inheritdoc cref="OnLoadedTemplate" />
    [XamlOneWayBindingModeByDefault] public static readonly DependencyProperty OnLoadedTemplateProperty =
        DependencyProperty.Register(
            nameof(OnLoadedTemplate), typeof(DataTemplate), typeof(LoadAwaitingControl),
            new PropertyMetadata(default(DataTemplate)));

    [XamlOneWayBindingModeByDefault] public static readonly DependencyProperty StatusIndicatorProperty =
        DependencyProperty.Register(
            nameof(ViewModels.StatusIndicator), typeof(StatusIndicator), typeof(LoadAwaitingControl),
            new PropertyMetadata(default(StatusIndicator)));

    /// <inheritdoc cref="LoadingTemplate" />
    [XamlOneWayBindingModeByDefault] public static readonly DependencyProperty LoadingTemplateProperty =
        DependencyProperty.Register(
            nameof(LoadingTemplate), typeof(DataTemplate), typeof(LoadAwaitingControl),
            new PropertyMetadata(Application.Current.Resources["DefaultLoadAwaitingDataTemplate"]));

    public LoadAwaitingControl()
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

    public StatusIndicator StatusIndicator
    {
        get => (StatusIndicator)GetValue(StatusIndicatorProperty);
        set => SetValue(StatusIndicatorProperty, value);
    }
}