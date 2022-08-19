using ToDoList.Domain.Models;
using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Commands
{
    internal class OpenEditNoteCommand : BaseCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly NotesListingItemViewModel _notesListingItemViewModel;
        private readonly NotesStore _notesStore;
        public OpenEditNoteCommand(NotesListingItemViewModel notesListingItemViewModel, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            _notesListingItemViewModel = notesListingItemViewModel;
            _modalNavigationStore = modalNavigationStore;
            _notesStore = notesStore;
        }

        public override void Execute(object parameter)
        {
            Note note = _notesListingItemViewModel.Note;
            EditNoteViewModel editNoteViewModel = new EditNoteViewModel(note, _notesStore, _modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editNoteViewModel;
        }
    }
}
