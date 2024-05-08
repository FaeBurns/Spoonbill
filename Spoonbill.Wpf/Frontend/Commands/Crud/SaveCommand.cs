using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.Commands.Crud;

public class SaveCommand : SimpleCommand
{
    private readonly object m_model;
    private readonly ICrudTemplate m_template;
    private readonly IntrospectMode m_mode;

    public SaveCommand(object model, ICrudTemplate template, IntrospectMode mode)
    {
        m_model = model;
        m_template = template;
        m_mode = mode;
    }
    
    public override void Execute(object? parameter)
    {
        m_template.Save(m_model, m_mode);
    }
}