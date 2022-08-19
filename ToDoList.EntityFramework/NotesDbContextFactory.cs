using Microsoft.EntityFrameworkCore;

namespace ToDoList.EntityFramework
{
    public class NotesDbContextFactory
    {

        private readonly DbContextOptions _options;

        public NotesDbContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public NotesDbContext Create()
        {
            return new NotesDbContext(_options);
        }
    }
}
