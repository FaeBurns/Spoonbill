using System.Collections.ObjectModel;
using System.Windows;

namespace Spoonbill.Wpf.Frontend.Commands;

public class MoveUpInCollectionCommand<T> : SimpleCommand
{
    private readonly ObservableCollection<T> m_collection;

    public MoveUpInCollectionCommand(ObservableCollection<T> collection)
    {
        m_collection = collection;
    }

    public override void Execute(object? parameter)
    {
        if (parameter is null)
        {
            MessageBox.Show("Cannot move null element in collection");
            return;
        }

        if (parameter is not T obj)
        {
            MessageBox.Show($"Cannot move type {parameter.GetType()} in collection of type {typeof(T)}");
            return;
        }

        int index = m_collection.IndexOf(obj);
        if (index == -1)
        {
            MessageBox.Show("Cannot move item as it is not present in the collection");
            return;
        }

        if (index == 0)
            return;

        // invoke the move
        m_collection.Move(index, index - 1);
    }
}