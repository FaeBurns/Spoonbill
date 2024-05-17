namespace Spoonbill.Wpf.Frontend.ViewModels;

public class LazyLoadViewModel<T> where T : class
{
    private readonly Func<T> m_loader;
    private T? m_value = null;

    public LazyLoadViewModel(Func<T> loader)
    {
        m_loader = loader;
    }

    public T Value
    {
        get
        {
            if (m_value == null)
            {
                m_value = m_loader.Invoke();
            }

            return m_value;
        }
    }
}