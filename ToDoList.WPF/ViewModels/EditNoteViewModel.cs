using System;
using System.Windows.Input;
using ToDoList.Domain.Models;
using ToDoList.WPF.Commands;
using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class EditNoteViewModel : BaseViewModel
    {
        public EditNoteViewModel(Note note, NotesStore notesStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand acceptCommand = new EditNoteCommand(this, notesStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            NotesDetailsFormViewModel = new NotesDetailsFormViewModel(acceptCommand, cancelCommand)
            {
                Title = note.Title,
                Description = note.Description,
                Date = note.Date,
            };
            NoteId = note.Id;
        }
        public Guid NoteId { get; }
        public NotesDetailsFormViewModel NotesDetailsFormViewModel { get; }
    }
}
