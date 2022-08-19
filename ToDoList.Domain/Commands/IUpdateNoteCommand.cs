using ToDoList.Domain.Models;

namespace ToDoList.Domain.Commands
{
    public interface IUpdateNoteCommand
    {
        Task Execute(Note note);
    }
}
