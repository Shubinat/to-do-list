using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoList.Domain.Commands;
using ToDoList.Domain.Models;
using ToDoList.Domain.Queries;

namespace ToDoList.WPF.Stores
{
    public class NotesStore
    {
        public event Action NotesLoaded;
        public event Action<Note> NoteAdded;
        public event Action<Note> NoteUpdated;
        public event Action<Guid> NoteDeleted;

        private readonly ICreateNoteCommand _createNoteCommand;
        private readonly IDeleteNoteCommand _deleteNoteCommand;
        private readonly IUpdateNoteCommand _updateNoteCommand;
        private readonly IGetAllNotesQuery _getAllNotesQuery;

        private readonly List<Note> _notes;

        public NotesStore(ICreateNoteCommand createNoteCommand,
            IDeleteNoteCommand deleteNoteCommand,
            IUpdateNoteCommand updateNoteCommand,
            IGetAllNotesQuery getAllNotesQuery)
        {
            _createNoteCommand = createNoteCommand;
            _deleteNoteCommand = deleteNoteCommand;
            _updateNoteCommand = updateNoteCommand;
            _getAllNotesQuery = getAllNotesQuery;

            _notes = new List<Note>();
        }

        public IEnumerable<Note> Notes => _notes;

        public async Task Load()
        {
            IEnumerable<Note> notes = await _getAllNotesQuery.Execute();

            _notes.Clear();
            _notes.AddRange(notes);
            NotesLoaded?.Invoke();
        }

        public async Task AddNote(Note note)
        {
            await _createNoteCommand.Execute(note);

            _notes.Add(note);

            NoteAdded?.Invoke(note);
        }

        public async Task UpdateNote(Note note)
        {
            await _updateNoteCommand.Execute(note);

            int currIndex = _notes.FindIndex(n => n.Id == note.Id);
            if(currIndex != -1)
            {
                _notes[currIndex] = note;
            }
            else
            {
                _notes.Add(note);
            }

            NoteUpdated?.Invoke(note);
        }

        public async Task DeleteNote(Guid id)
        {
            await _deleteNoteCommand.Execute(id);

            _notes.RemoveAll(n => n.Id == id);

            NoteDeleted?.Invoke(id);
        }
    }
}
