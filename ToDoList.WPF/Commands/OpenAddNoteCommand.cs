using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Commands
{
    public class OpenAddNoteCommand : BaseCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NotesStore _notesStore;
        public OpenAddNoteCommand(NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _notesStore = notesStore;
        }
        public override void Execute(object parameter)
        {
           _modalNavigationStore.CurrentViewModel = new AddNoteViewModel(_notesStore, _modalNavigationStore);
        }
    }
}
