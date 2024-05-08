using Spoonbill.Wpf.Frontend.ViewModels.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.Commands.Crud;

public class CreateCommand : SimpleCommand
{
    private readonly object m_model;
    private readonly ICrudTemplate m_template;
    private readonly CrudHostViewModel m_hostViewModel;

    public CreateCommand(object model, ICrudTemplate template, CrudHostViewModel hostViewModel)
    {
        m_model = model;
        m_template = template;
        m_hostViewModel = hostViewModel;
    }

    public override void Execute(object? parameter)
    {
        m_hostViewModel.SelectedItem = new CrudIntrospectItemViewModel(m_model, m_template, m_hostViewModel, IntrospectMode.CREATE);
    }
}