using System.Windows.Input;
using Spoonbill.Wpf.Frontend.Commands;
using Spoonbill.Wpf.Frontend.Commands.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.IntrospectViewModels;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudIntrospectItemViewModel : ViewModel
{
    private readonly Func<IIntrospectViewModel> m_itemBuilder;
    private readonly CrudHostViewModel m_hostViewModel;
    private IIntrospectViewModel? m_item;
    private ICommand m_saveCommand = new DisabledCommand();

    public CrudIntrospectItemViewModel(Func<IIntrospectViewModel> itemBuilder, ICrudTemplate template, CrudHostViewModel hostViewModel, IntrospectMode mode)
    {
        m_itemBuilder = itemBuilder;
        m_hostViewModel = hostViewModel;
        Template = template;
        IntrospectMode = mode;

        CancelCommand = new ReturnToListCommand(hostViewModel);
    }

    public ICrudTemplate Template { get; }

    public IIntrospectViewModel Item
    {
        get
        {
            if (m_item == null)
            {
                m_item = m_itemBuilder.Invoke();
                if (IntrospectMode != IntrospectMode.READ)
                    SaveCommand = new SaveCommand(Item, Template, m_hostViewModel, IntrospectMode);
                // default is already disabled
            }

            return m_item;
        }
    }
    public IntrospectMode IntrospectMode { get; }

    public ICommand SaveCommand
    {
        get => m_saveCommand;
        private set => SetField(ref m_saveCommand, value);
    }
    public ICommand CancelCommand { get; }
}