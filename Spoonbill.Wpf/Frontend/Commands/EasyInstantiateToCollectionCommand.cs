using System.Collections.ObjectModel;

namespace Spoonbill.Wpf.Frontend.Commands;

public class EasyInstantiateToCollectionCommand<T> : SimpleCommand where T : new()
{
    private readonly ObservableCollection<T> m_collection;

    public EasyInstantiateToCollectionCommand(ObservableCollection<T> collection)
    {
        m_collection = collection;
    }

    public override void Execute(object? parameter)
    {
        m_collection.Add(new T());
    }
}