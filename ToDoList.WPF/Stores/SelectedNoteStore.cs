using System;
using ToDoList.Domain.Models;

namespace ToDoList.WPF.Stores
{
    public class SelectedNoteStore
    {
        public event Action SelectedNoteChanged;

        private readonly NotesStore _notesStore;

        private Note _note;
        public SelectedNoteStore(NotesStore notesStore)
        {
            _notesStore = notesStore;

            _notesStore.NoteUpdated += NotesStore_NoteUpdated;
            _notesStore.NoteAdded += NotesStore_NoteAdded;
            _notesStore.NoteDeleted += NotesStore_NoteDeleted;
        }

        public Note SelectedNote
        {
            get 
            { 
                return _note; 
            }
            set 
            { 
                _note = value;
                SelectedNoteChanged?.Invoke();
            }
        }

        private void NotesStore_NoteUpdated(Note note)
        {
            if (SelectedNote.Id == note.Id)
            {
                SelectedNote = note;
            }
        }
        private void NotesStore_NoteDeleted(Guid id)
        {
            SelectedNote = null;
        }
        private void NotesStore_NoteAdded(Note note)
        {
            SelectedNote = note;
        }
    }
}
