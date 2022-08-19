using Microsoft.EntityFrameworkCore;
using ToDoList.EntityFramework.DTOs;

namespace ToDoList.EntityFramework
{
    public class NotesDbContext : DbContext
    {
        public DbSet<NoteDTO> Notes { get; set; }
        public NotesDbContext(DbContextOptions options) : base(options)
        {
           
        }
    }
}
