using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [Route("api/task")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] UpdateTaskDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _taskService.Update(id, dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            _taskService.Delete(id);

            return NoContent();
        }


        [HttpPost]
        public ActionResult CreateTask([FromBody] CreateTaskDto taskDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var id = _taskService.Create(taskDto);

            return Created($"/api/task/{id}", null);
        }


        [HttpGet]
        public ActionResult<IEnumerable<TaskDto>> GetAll()
        {
            var tasksDtos = _taskService.GetAll();

            return Ok(tasksDtos);
        }

        [HttpGet("{id}")]
        public ActionResult<TaskDto> Get([FromRoute] int id)
        {
            var task = _taskService.GetById(id);

            return Ok(task);
        }
    }
}
