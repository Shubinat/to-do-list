using ToDoList.Domain.Commands;
using ToDoList.Domain.Models;
using ToDoList.EntityFramework.DTOs;

namespace ToDoList.EntityFramework.Commands
{
    public class CreateNoteCommand : ICreateNoteCommand
    {
        private readonly NotesDbContextFactory _dbContextFactory;

        public CreateNoteCommand(NotesDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Execute(Note note)
        {
            using NotesDbContext context = _dbContextFactory.Create();

            NoteDTO noteDTO = new NoteDTO(note.Id, note.Title, note.Description, note.Date);

            context.Notes.Add(noteDTO);

            await context.SaveChangesAsync();
        }
    }
}
