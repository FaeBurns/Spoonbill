using System.Collections.ObjectModel;
using Spoonbill.Wpf.Frontend.Commands.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudHostViewModel : ViewModel
{
    private readonly ICrudTemplate m_template;
    private CrudIntrospectItemViewModel? m_selectedItem = null;
    private ObservableCollection<CrudListItemViewModel> m_entries = new ObservableCollection<CrudListItemViewModel>();

    public CrudHostViewModel(ICrudTemplate template)
    {
        m_template = template;
        Entries = new ObservableCollection<CrudListItemViewModel>(template.BuildList().Select(BuildListItem));
    }

    public StatusIndicator StatusIndicator { get; } = new StatusIndicator();

    public ObservableCollection<CrudListItemViewModel> Entries
    {
        get => m_entries;
        set => SetField(ref m_entries, value);
    }

    public CrudIntrospectItemViewModel? SelectedItem
    {
        get => m_selectedItem;
        set => SetField(ref m_selectedItem, value);
    }

    private CrudListItemViewModel BuildListItem(object model)
    {
        return new CrudListItemViewModel(model,
            new EditCommand(model, m_template, this),
            new InspectCommand(model, m_template, this),
            new DeleteCommand(model, m_template));
    }
}