using System.Windows.Input;
using Spoonbill.Wpf.Frontend.Commands;
using Spoonbill.Wpf.Frontend.Commands.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudIntrospectItemViewModel
{
    public CrudIntrospectItemViewModel(IIntrospectViewModel item, ICrudTemplate template, CrudHostViewModel hostViewModel, IntrospectMode mode)
    {
        Template = template;
        Item = item;
        IntrospectMode = mode;

        if (mode != IntrospectMode.READ)
            SaveCommand = new SaveCommand(item, template, hostViewModel, mode);
        else
            SaveCommand = new DisabledCommand();

        CancelCommand = new ReturnToListCommand(hostViewModel);
    }

    public ICrudTemplate Template { get; }
    public IIntrospectViewModel Item { get; }
    public IntrospectMode IntrospectMode { get; }
    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }
}