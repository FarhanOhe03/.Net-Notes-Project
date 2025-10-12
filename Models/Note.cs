namespace NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastModifiedDate { get; set; }
        public Priority Priority { get; set; } = Priority.Low;

    }
    

     public enum Priority
    {
        Low,
        Medium,
        High
    }
}
