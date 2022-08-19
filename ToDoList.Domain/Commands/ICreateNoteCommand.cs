using ToDoList.Domain.Models;

namespace ToDoList.Domain.Commands
{
    public interface ICreateNoteCommand
    {
        Task Execute(Note note);
    }
}
