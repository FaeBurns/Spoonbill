using System.Collections.ObjectModel;

namespace Spoonbill.Wpf.Frontend.ViewModels;

public class ProgressViewModel<T> : ViewModel, IProgress<T>
{
    private T m_latestValue = default!;

    public T LatestValue
    {
        get => m_latestValue;
        private set => SetField(ref m_latestValue, value);
    }

    public void Report(T value)
    {
        LatestValue = value;
    }
}