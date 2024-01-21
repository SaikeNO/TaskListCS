using Microsoft.AspNetCore.Mvc;
using WebApplication3.Entities;
using Task = WebApplication3.Entities.Task;

namespace WebApplication3.Controllers
{
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly TaskDbContext _dbContext;
        public TaskController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAll()
        {
            var tasks = _dbContext.Tasks.ToList();

            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<Task> Get([FromRoute] int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            
            if (task == null)
            {
                return NotFound();
            }

            return Ok(task);
        }
    }
}
