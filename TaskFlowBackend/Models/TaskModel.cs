using System.ComponentModel.DataAnnotations;

namespace TaskFlowBackend.Models
{
    public class TaskModel
    {
        [Key] // This marks TaskId as the primary key
        public int TaskId { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int UserID { get; set; }
    }
}
