using WebApplication3.Entities;
using Task = WebApplication3.Entities.Task;

namespace WebApplication3
{
    public class TaskSeeder
    {
        private readonly TaskListDbContext _dbContext;
        public TaskSeeder(TaskListDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Tasks.Any())
                {
                    var tasks = GetTasks();
                    _dbContext.Tasks.AddRange(tasks);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Task> GetTasks()
        {
            return new List<Task>()
            {
                new Task()
                {
                    Name = "Zrobić pranie",
                    Description = "Trzeba coś tam zrobić",
                },

                new Task()
                {
                    Name = "Pouczyć się",
                    Description = "Napisać jakiś kawałek kodu na studia",
                },
            };
        }
    }
}
