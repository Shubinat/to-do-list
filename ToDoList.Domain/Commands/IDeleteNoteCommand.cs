namespace ToDoList.Domain.Commands
{
    public interface IDeleteNoteCommand
    {
        Task Execute(Guid id);
    }
}
