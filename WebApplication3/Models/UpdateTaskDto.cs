using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class UpdateTaskDto
    {
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public bool IsDone { get; set; }
    }
}
