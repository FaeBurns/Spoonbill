using System.Diagnostics;
using System.Windows.Input;

namespace Spoonbill.Wpf.Frontend.Commands;

public class DisabledCommand : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return false;
    }

    public void Execute(object? parameter)
    {
        throw new UnreachableException();
    }

#pragma warning disable CS0067
    public event EventHandler? CanExecuteChanged;
#pragma warning restore
}