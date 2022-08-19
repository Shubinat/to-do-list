using ToDoList.Domain.Models;

namespace ToDoList.Domain.Queries
{
    public interface IGetAllNotesQuery
    {
        Task<IEnumerable<Note>> Execute();
    }
}
