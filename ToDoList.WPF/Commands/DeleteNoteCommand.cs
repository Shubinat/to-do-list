using System;
using System.Threading.Tasks;
using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Commands
{
    public class DeleteNoteCommand : AsyncCommand
    {
        private readonly NotesListingItemViewModel _notesListingItemViewModel;
        private readonly NotesStore _notesStore;
        public DeleteNoteCommand(NotesListingItemViewModel notesListingItemViewModel, NotesStore notesStore)
        {
            _notesListingItemViewModel = notesListingItemViewModel;
            _notesStore = notesStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            _notesListingItemViewModel.IsDeleting = true;
            Guid id = _notesListingItemViewModel.Note.Id;
            try
            { 
                await _notesStore.DeleteNote(id);
            }
            catch 
            {
                _notesListingItemViewModel.ErrorMessage = "Failed to delete note. Please try again later.";
            }
            finally
            {
                _notesListingItemViewModel.IsDeleting = false;
            }
        }
    }
}
