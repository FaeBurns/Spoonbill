using System.Collections.ObjectModel;
using System.Windows;
using Spoonbill.Wpf.Frontend.Commands.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudHostViewModel : ViewModel
{
    private bool m_hasLoadedEntries;

    private readonly ICrudTemplate m_template;
    private List<CrudListItemViewModel> m_entries = new List<CrudListItemViewModel>();
    private CrudIntrospectItemViewModel? m_selectedItem;

    public CrudHostViewModel(ICrudTemplate template)
    {
        m_template = template;
        ReloadEntriesAsync();
    }

    /// <summary>
    /// Reloads all entries from the database.
    /// This method will return immediately.
    /// </summary>
    public void ReloadEntriesAsync()
    {
        new Thread(PopulateList).Start();
    }

    private void PopulateList()
    {
        IEnumerable<CrudListItemViewModel> viewModels = m_template.BuildList().Select(BuildListItem);
        Entries = new List<CrudListItemViewModel>(viewModels);
        HasLoadedEntries = true;
    }

    public bool HasLoadedEntries
    {
        get => m_hasLoadedEntries;
        set => SetField(ref m_hasLoadedEntries, value);
    }

    public List<CrudListItemViewModel> Entries
    {
        get => m_entries;
        set => SetField(ref m_entries, value);
    }

    public CrudIntrospectItemViewModel? SelectedItem
    {
        get => m_selectedItem;
        set
        {
            if (SetField(ref m_selectedItem, value))
            {
                OnPropertyChanged(nameof(HasSelectedItem));
            }
        }
    }

    public bool HasSelectedItem => m_selectedItem != null;

    private CrudListItemViewModel BuildListItem(object model)
    {
        return new CrudListItemViewModel(model,
            new EditCommand(model, m_template, this),
            new InspectCommand(model, m_template, this),
            new DeleteCommand(model, m_template, this));
    }
}