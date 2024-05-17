using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Spoonbill.Wpf.Frontend.ViewModels;

public class StatusIndicator : ViewModel, IProgress<bool>
{
    private bool m_status;

    public bool Status
    {
        get => m_status;
        private set => SetField(ref m_status, value);
    }

    public void Report(bool value)
    {
        Application.Current.Dispatcher.Invoke(() => { Status = value; });
    }
}