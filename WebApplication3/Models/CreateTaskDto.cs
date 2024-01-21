using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class CreateTaskDto
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Date { get; set; }
    }
}
