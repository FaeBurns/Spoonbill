using System.Collections.ObjectModel;
using System.Windows;

namespace Spoonbill.Wpf.Frontend.Commands;

public class RemoveFromCollectionCommand<T> : SimpleCommand
{
    private readonly ObservableCollection<T> m_collection;

    public RemoveFromCollectionCommand(ObservableCollection<T> collection)
    {
        m_collection = collection;
    }

    public override void Execute(object? parameter)
    {
        if (parameter is null)
        {
            MessageBox.Show("Cannot remove null element from collection");
            return;
        }

        if (parameter is not T casted)
        {
            MessageBox.Show($"Failed to remove object of type {parameter.GetType()} from collection of type {typeof(T)}");
            return;
        }
        m_collection.Remove(casted);
    }
}