using System.Collections.ObjectModel;

namespace Spoonbill.Wpf.Frontend.Commands;

public class InstantiateToCollectionCommand<T> : SimpleCommand
{
    private readonly ObservableCollection<T> m_collection;
    private readonly Func<T> m_buildInvoke;

    public InstantiateToCollectionCommand(ObservableCollection<T> collection, Func<T> buildInvoke)
    {
        m_collection = collection;
        m_buildInvoke = buildInvoke;
    }

    public override void Execute(object? parameter)
    {
        m_collection.Add(m_buildInvoke.Invoke());
    }
}