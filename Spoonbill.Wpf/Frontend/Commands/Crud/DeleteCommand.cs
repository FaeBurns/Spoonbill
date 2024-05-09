using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

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
        m_template.Delete(m_model);
    }
}