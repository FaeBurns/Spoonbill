using System.Windows.Input;

namespace Spoonbill.Wpf.Frontend.ViewModels.Crud;

public class CrudListItemViewModel : ViewModel
{
     private bool m_readOnly;

     public CrudListItemViewModel(object crudObject, ICommand editCommand, ICommand inspectCommand, ICommand deleteCommand)
     {
          CrudObject = crudObject;
          EditCommand = editCommand;
          InspectCommand = inspectCommand;
          DeleteCommand = deleteCommand;
     }

     public object CrudObject { get; }
     public ICommand EditCommand { get; }
     public ICommand InspectCommand { get; }
     public ICommand DeleteCommand { get; }

     public bool ReadOnly
     {
          get => m_readOnly;
          set => SetField(ref m_readOnly, value);
     }
}