using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ToDoList.Domain.Models;
using ToDoList.WPF.Commands;
using ToDoList.WPF.Stores;

namespace ToDoList.WPF.ViewModels
{
    public class NotesListingViewModel : BaseViewModel
    {
        private readonly SelectedNoteStore _selectedNoteStore;
        private readonly NotesStore _notesStore;
        private readonly ObservableCollection<NotesListingItemViewModel> _notes = new ObservableCollection<NotesListingItemViewModel>();
        private readonly ModalNavigationStore _modalNavigationStore;
        private NotesListingItemViewModel _selectedNote;

        public NotesListingViewModel(NotesStore notesStore, SelectedNoteStore selectedNoteStore, ModalNavigationStore modalNavigationStore)
        {
            _selectedNoteStore = selectedNoteStore;
            _notesStore = notesStore;
            _modalNavigationStore = modalNavigationStore;

            _notesStore.NoteAdded += NotesStore_NoteAdded;
            _notesStore.NoteUpdated += NotesStore_NoteUpdated;
            _notesStore.NotesLoaded += NotesStore_NotesLoaded;
            _notesStore.NoteDeleted += NotesStore_NoteDeleted;
            _notes.CollectionChanged += Notes_CollectionChanged;
        }


        public NotesListingItemViewModel SelectedNote
        {
            get
            {
                return _notes.FirstOrDefault(n => n.Note?.Id == _selectedNoteStore.SelectedNote?.Id);
            }
            set
            {

                _selectedNoteStore.SelectedNote = value?.Note;
            }
        }
        public IEnumerable<NotesListingItemViewModel> Notes => _notes;

       
        private void AddNote(Note note)
        {
            _notes.Add(new NotesListingItemViewModel(note, _notesStore, _modalNavigationStore));
        }
        private void NotesStore_NoteAdded(Note note)
        {
            AddNote(note);
        }
        private void NotesStore_NoteUpdated(Note note)
        {
            NotesListingItemViewModel notesListingItemViewModel = _notes.FirstOrDefault(n => n.Note.Id == note.Id);
            if (notesListingItemViewModel != null)
            {
                notesListingItemViewModel.Update(note);
            }
        }
        private void NotesStore_NotesLoaded()
        {
            _notes.Clear();
            foreach (Note note in _notesStore.Notes)
            {
                AddNote(note);
            }
        }
        private void NotesStore_NoteDeleted(Guid id)
        {
            NotesListingItemViewModel notesListingItemViewModel = _notes.FirstOrDefault(n => n.Note.Id == id);

            if(notesListingItemViewModel != null)
            {
                _notes.Remove(notesListingItemViewModel);
            }
        }
        private void Notes_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedNote));
        }
        public override void Dispose()
        {
            _notesStore.NoteAdded -= NotesStore_NoteAdded;
            _notesStore.NoteUpdated -= NotesStore_NoteUpdated;
            _notesStore.NotesLoaded -= NotesStore_NotesLoaded;
            _notesStore.NoteDeleted -= NotesStore_NoteDeleted;
            _notes.CollectionChanged -= Notes_CollectionChanged;


            base.Dispose();
        }
    }
}
