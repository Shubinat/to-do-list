using System.Windows.Input;
using ToDoList.WPF.Commands;
using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class AddNoteViewModel : BaseViewModel
    {
        public AddNoteViewModel(NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand acceptCommand = new AddNoteCommand(this, notesStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            NotesDetailsFormViewModel = new NotesDetailsFormViewModel(acceptCommand,cancelCommand);
        }
        public NotesDetailsFormViewModel NotesDetailsFormViewModel { get; }
    }
}
