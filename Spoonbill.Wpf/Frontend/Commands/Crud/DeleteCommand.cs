using System.Windows;
using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.Commands.Crud;

public class DeleteCommand : SimpleCommand
{
    private readonly object m_model;
    private readonly ICrudTemplate m_template;
    private readonly CrudHostViewModel m_hostViewModel;

    public DeleteCommand(object model, ICrudTemplate template, CrudHostViewModel hostViewModel)
    {
        m_model = model;
        m_template = template;
        m_hostViewModel = hostViewModel;
    }

    public override void Execute(object? parameter)
    {
        // get confirmation from user
        // return if the answer was not an ok
        MessageBoxResult questionResult = MessageBox.Show("Are you sure you wish to delete this entry?", "Are you sure?", MessageBoxButton.YesNo, MessageBoxImage.Question);
        if (questionResult != MessageBoxResult.Yes)
            return;

        IResult result = m_template.Delete(m_model);

        if (result is Ok)
        {
            m_hostViewModel.ReloadEntriesAsync();
            MessageBox.Show("Entry deleted successfully.", "Success!", MessageBoxButton.OK, MessageBoxImage.None);
        }
        else if (result is Error error)
        {
            MessageBox.Show(error.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}