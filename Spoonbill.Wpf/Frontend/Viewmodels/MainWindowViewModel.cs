namespace Spoonbill.Wpf.Frontend.ViewModels;

public class MainWindowViewModel : ViewModel
{
    public MainWindowViewModel()
    {
    }

    public StatusIndicator DatabaseConnectionIndicator { get; } = new StatusIndicator();
}