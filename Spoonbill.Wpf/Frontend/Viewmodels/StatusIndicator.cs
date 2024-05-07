using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Spoonbill.Wpf.Frontend.ViewModels;

public class StatusIndicator : IProgress<bool>, INotifyPropertyChanged
{
    private bool m_status;

    public bool Status
    {
        get => m_status;
        private set => SetField(ref m_status, value);
    }

    public void Report(bool value)
    {
        Status = value;
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