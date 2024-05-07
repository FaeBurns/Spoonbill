using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Spoonbill.Wpf.Frontend.ViewModels;
using JetBrains.Annotations;

namespace Spoonbill.Wpf.Frontend.View.UserControls;

public partial class LoadAwaitingControl : UserControl
{
    private bool m_loaded = false;

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty OnLoadedTemplateProperty = DependencyProperty.Register(
        nameof(OnLoadedTemplate), typeof(ControlTemplate), typeof(LoadAwaitingControl), new PropertyMetadata(default(ControlTemplate)));

    [XamlOneWayBindingModeByDefault]
    public static readonly DependencyProperty StatusIndicatorProperty = DependencyProperty.Register(
        nameof(ViewModels.StatusIndicator), typeof(StatusIndicator), typeof(LoadAwaitingControl), new PropertyMetadata(default(StatusIndicator), propertyChangedCallback: StatusIndicatorChangedCallback));

    public event EventHandler? AwaitingContentLoaded;

    public LoadAwaitingControl()
    {
        InitializeComponent();
    }

    public ControlTemplate OnLoadedTemplate
    {
        get => (ControlTemplate)GetValue(OnLoadedTemplateProperty);
        set => SetValue(OnLoadedTemplateProperty, value);
    }

    public StatusIndicator StatusIndicator
    {
        get => (StatusIndicator)GetValue(StatusIndicatorProperty);
        set => SetValue(StatusIndicatorProperty, value);
    }

    public void LoadWaitingContent()
    {
        // do nothing if content is already loaded
        if (m_loaded)
            return;

        // load child control from template
        LoadedContentHost.Template = OnLoadedTemplate;

        // notify
        m_loaded = true;
        AwaitingContentLoaded?.Invoke(this, EventArgs.Empty);
    }

    private void BindToStatusIndicator(StatusIndicator? oldIndicator, StatusIndicator? newIndicator)
    {
        if (oldIndicator == newIndicator)
            return;

        if (oldIndicator != null)
            oldIndicator.PropertyChanged -= StatusIndicator_OnPropertyChange;

        if (newIndicator != null)
        {
            newIndicator.PropertyChanged += StatusIndicator_OnPropertyChange;
            HandleStatusUpdate(newIndicator);
        }
    }

    private void StatusIndicator_OnPropertyChange(object? sender, PropertyChangedEventArgs e)
    {
        HandleStatusUpdate(StatusIndicator);
    }

    private void HandleStatusUpdate(StatusIndicator workReport)
    {
        if (workReport.Status)
        {
            LoadWaitingContent();
        }
    }

    private static void StatusIndicatorChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        LoadAwaitingControl control = (d as LoadAwaitingControl)!;

        control.BindToStatusIndicator(e.OldValue as StatusIndicator, e.NewValue as StatusIndicator);
        control.HandleStatusUpdate((e.NewValue as StatusIndicator)!);
    }
}