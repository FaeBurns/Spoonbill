using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Spoonbill.Wpf.Frontend.ViewModels;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null, params string[] otherPropertyNames)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        foreach (string name in otherPropertyNames) OnPropertyChanged(name);
        return true;
    }

    public void RefreshAll()
    {
        OnPropertyChanged(String.Empty);
    }
}