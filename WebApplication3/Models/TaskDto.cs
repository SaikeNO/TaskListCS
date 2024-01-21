namespace WebApplication3.Models
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }
}
