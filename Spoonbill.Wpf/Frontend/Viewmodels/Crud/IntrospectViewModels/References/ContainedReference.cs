using Spoonbill.Wpf.Frontend.Extensions;
using Spoonbill.Wpf.Frontend.ViewModels;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

public class ContainedReference<T> : ViewModel where T : class, new()
{
    private T m_value = null!;

    public T Value
    {
        get => m_value;
        set => SetField(ref m_value, value);
    }

    public ContainedReference(T value)
    {
        m_value = value;
    }

    public ContainedReference()
    {
        m_value = new T();
    }
}

public class ContainedReferenceTypeResolver : GenericTypeResolver
{
    public override Type Resolve()
    {
        return typeof(ContainedReference<>);
    }
}