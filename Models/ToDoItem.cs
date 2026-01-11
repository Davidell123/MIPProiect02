using SQLite;

namespace MIPProiect02.Models
{
    public class TodoItem
    {
         
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public bool IsCompleted { get; set; }

        public DateTime DueDate { get; set; }

        
        public string? Description { get; set; }
    }
}