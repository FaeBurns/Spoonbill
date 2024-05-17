namespace Spoonbill.Wpf.Frontend.ViewModels;

public class MainWindowViewModel : ViewModel
{
    private bool m_readMe;

    public MainWindowViewModel()
    {
        DatabaseConnectionIndicator = new Progress<bool>((b => ReadMe = b));
    }

    public IProgress<bool> DatabaseConnectionIndicator { get; }

    public bool ReadMe
    {
        get => m_readMe;
        set => SetField(ref m_readMe, value);
    }
}