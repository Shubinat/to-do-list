namespace ToDoList.Domain.Models
{
    public class Note
    {
        public Note(Guid id, string title, string description, DateTime date)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
        }
        public Guid Id { get; }
        public string Title { get; }
        public string Description { get; }
        public DateTime Date { get; }
    }
}
