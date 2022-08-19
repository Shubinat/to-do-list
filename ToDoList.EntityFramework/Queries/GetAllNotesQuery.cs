using Microsoft.EntityFrameworkCore;
using ToDoList.Domain.Models;
using ToDoList.Domain.Queries;
using ToDoList.EntityFramework.DTOs;

namespace ToDoList.EntityFramework.Queries
{
    public class GetAllNotesQuery : IGetAllNotesQuery
    {
        private readonly NotesDbContextFactory _dbContextFactory;

        public GetAllNotesQuery(NotesDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<IEnumerable<Note>> Execute()
        {
            using NotesDbContext context = _dbContextFactory.Create();

            IEnumerable<NoteDTO> notesDTOs = await context.Notes.ToListAsync();

            return notesDTOs.Select(n => new Note(n.Id, n.Title, n.Description, n.Date));
        }
    }
}
