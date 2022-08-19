using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Commands;
using ToDoList.EntityFramework.DTOs;

namespace ToDoList.EntityFramework.Commands
{
    public class DeleteNoteCommand : IDeleteNoteCommand
    {
        private readonly NotesDbContextFactory _dbContextFactory;

        public DeleteNoteCommand(NotesDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Execute(Guid id)
        {
            using NotesDbContext context = _dbContextFactory.Create();

            NoteDTO noteDTO = new NoteDTO() { Id = id };

            context.Notes.Remove(noteDTO);

            await context.SaveChangesAsync();
        }
    }
}
