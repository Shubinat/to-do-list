using System;
using System.Threading.Tasks;
using ToDoList.Domain.Models;
using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Commands
{
    public class EditNoteCommand : AsyncCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly EditNoteViewModel _editNoteViewModel;
        private readonly NotesStore _notesStore;
        public EditNoteCommand(EditNoteViewModel editNoteViewModel, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _editNoteViewModel = editNoteViewModel;
            _notesStore = notesStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            NotesDetailsFormViewModel formViewModel = _editNoteViewModel.NotesDetailsFormViewModel;
            formViewModel.IsAccepting = true;
            try
            {
                Note note = 
                    new Note(_editNoteViewModel.NoteId, formViewModel.Title, formViewModel.Description, formViewModel.Date.Value);

                await _notesStore.UpdateNote(note);

                _modalNavigationStore.Close();
            }
            catch
            {
                _editNoteViewModel.NotesDetailsFormViewModel.ErrorMessage = "Failed to update the note. Please try again later.";
            }
            finally
            {
                formViewModel.IsAccepting = false;
            }
        }
    }
}
