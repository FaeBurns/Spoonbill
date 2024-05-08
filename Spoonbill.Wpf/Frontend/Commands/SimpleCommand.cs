using System.Windows.Input;

namespace Spoonbill.Wpf.Frontend.Commands;

public abstract class SimpleCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;
}