using Spoonbill.Wpf.Frontend.ViewModels.Crud;

namespace Spoonbill.Wpf.Frontend.Commands.Crud;

public class ReturnToListCommand : SimpleCommand
{
    private readonly CrudHostViewModel m_hostViewModel;

    public ReturnToListCommand(CrudHostViewModel hostViewModel)
    {
        m_hostViewModel = hostViewModel;
    }

    public override void Execute(object? parameter)
    {
        m_hostViewModel.SelectedItem = null;
    }
}