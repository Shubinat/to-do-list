using System;
using System.Threading.Tasks;
using ToDoList.Domain.Models;
using ToDoList.WPF.Stores;
using ToDoList.WPF.ViewModels;

namespace ToDoList.WPF.Commands
{
    public class AddNoteCommand : AsyncCommand
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly AddNoteViewModel _addNoteViewModel;
        private readonly NotesStore _notesStore;
        public AddNoteCommand(AddNoteViewModel addNoteViewModel, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
            _addNoteViewModel = addNoteViewModel;
            _notesStore = notesStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            NotesDetailsFormViewModel formViewModel = _addNoteViewModel.NotesDetailsFormViewModel;
            formViewModel.IsAccepting = true;
            try
            {
                Note note = 
                    new Note(Guid.NewGuid(), formViewModel.Title, formViewModel.Description, formViewModel.Date.Value);

                await _notesStore.AddNote(note);

                _modalNavigationStore.Close();
            }
            catch
            {
                _addNoteViewModel.NotesDetailsFormViewModel.ErrorMessage = "Failed to add the note. Please try again later.";
            }
            finally
            {
                formViewModel.IsAccepting = false;
            }
        }
    }
}
