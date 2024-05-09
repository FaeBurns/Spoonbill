using System.Collections.ObjectModel;
using System.Windows;
using Spoonbill.Wpf.Frontend.Commands.Crud;
using Spoonbill.Wpf.Frontend.ViewModels.Crud.Templates;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudHostViewModel : ViewModel
{
    private readonly ICrudTemplate m_template;
    private ObservableCollection<CrudListItemViewModel> m_entries = new ObservableCollection<CrudListItemViewModel>();
    private CrudIntrospectItemViewModel? m_selectedItem;

    public CrudHostViewModel(ICrudTemplate template)
    {
        m_template = template;
        new Thread(PopulateList).Start();
    }

    private void PopulateList()
    {
        IEnumerable<CrudListItemViewModel> viewModels = m_template.BuildList().Select(BuildListItem);
        Application.Current.Dispatcher.Invoke(() =>
        {
            Entries = new ObservableCollection<CrudListItemViewModel>(viewModels);
            StatusIndicator.Report(true);
        });
    }

    public StatusIndicator StatusIndicator { get; } = new StatusIndicator();
    public StatusIndicator HasItemSelectedIndicator { get; } = new StatusIndicator();

    public ObservableCollection<CrudListItemViewModel> Entries
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
                HasItemSelectedIndicator.Report(value != null);
            }
        }
    }

    private CrudListItemViewModel BuildListItem(object model)
    {
        return new CrudListItemViewModel(model,
            new EditCommand(model, m_template, this),
            new InspectCommand(model, m_template, this),
            new DeleteCommand(model, m_template));
    }
}