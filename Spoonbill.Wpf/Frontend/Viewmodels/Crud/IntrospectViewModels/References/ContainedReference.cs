using System.Collections;
using System.Windows.Data;
using JetBrains.Annotations;
using Spoonbill.Wpf.Frontend.Extensions;
using Spoonbill.Wpf.Frontend.ViewModels;

namespace Spoonbill.Wpf.Frontend.Viewmodels.Crud.IntrospectViewModels.References;

[UsedImplicitly(ImplicitUseKindFlags.Access, ImplicitUseTargetFlags.Members)]
public class ContainedReference<T> : ViewModel where T : class, new()
{
    private T m_value;

    public T Value
    {
        get => m_value;
        set => SetField(ref m_value, value);
    }

    public CollectionView CollectionView { get; }

    public ContainedReference(T value, IEnumerable collection)
    {
        m_value = value;
        CollectionView = new CollectionView(collection);
        CollectionView.MoveCurrentTo(value);
    }

    public ContainedReference(IEnumerable collection)
    {
        m_value = new T();
        CollectionView = new CollectionView(collection);
        CollectionView.MoveCurrentTo(null);
    }
}

public class ContainedReferenceTypeResolver : GenericTypeResolver
{
    public override Type Resolve()
    {
        return typeof(ContainedReference<>);
    }
}