namespace ToDoList.EntityFramework.DTOs
{
    public class NoteDTO
    {
        public NoteDTO()
        {

        }
        public NoteDTO(Guid id, string title, string description, DateTime date)
        {
            Id = id;
            Title = title;
            Description = description;
            Date = date;
        }
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

    }
}
