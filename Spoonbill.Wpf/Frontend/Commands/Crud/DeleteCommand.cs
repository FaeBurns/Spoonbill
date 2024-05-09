using System.Windows;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;
using Spoonbill.Wpf.Responses;

namespace Spoonbill.Wpf.Frontend.Commands.Crud;

public class DeleteCommand : SimpleCommand
{
    private readonly object m_model;
    private readonly ICrudTemplate m_template;

    public DeleteCommand(object model, ICrudTemplate template)
    {
        m_model = model;
        m_template = template;
    }

    public override void Execute(object? parameter)
    {
        IResult result = m_template.Delete(m_model);

        if (result is Ok)
        {
            MessageBox.Show("Entry deleted successfully.", "Success!", MessageBoxButton.OK, MessageBoxImage.None);
        }
        else if (result is Error error)
        {
            MessageBox.Show(error.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}