using System.Windows.Input;
using Spoonbill.Wpf.Frontend.Commands;
using Spoonbill.Wpf.Frontend.Commands.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudIntrospectItemViewModel
{
    private readonly ICrudTemplate m_template;

    public CrudIntrospectItemViewModel(object crudObject, ICrudTemplate template, CrudHostViewModel hostViewModel, IntrospectMode mode)
    {
        m_template = template;
        CrudObject = crudObject;
        IntrospectMode = mode;

        if (mode != IntrospectMode.READ)
            SaveCommand = new SaveCommand(crudObject, template, hostViewModel, mode);
        else
            SaveCommand = new DisabledCommand();
    }

    public object CrudObject { get; }
    public IntrospectMode IntrospectMode { get; }
    public ICommand SaveCommand { get; }
}