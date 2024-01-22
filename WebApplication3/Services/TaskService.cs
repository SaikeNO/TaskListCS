using AutoMapper;
using WebApplication3.Entities;
using WebApplication3.Exceptions;
using WebApplication3.Models;
using Task = WebApplication3.Entities.Task;

namespace WebApplication3.Services
{
    public class TaskService : ITaskService
    {
        private readonly TaskDbContext _dbContext;
        private readonly IMapper _mapper;

        public TaskService(TaskDbContext dbContext, IMapper mapper, ILogger<TaskService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Update(int id, UpdateTaskDto dto)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new NotFoundException("Task not found");

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Date = dto.Date;
            task.IsDone = dto.IsDone;

            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);
            
            if (task == null)
                throw new NotFoundException("Task not found");

            _dbContext.Tasks.Remove(task);
            _dbContext.SaveChanges();
        }

        public TaskDto GetById(int id)
        {
            var task = _dbContext.Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
                throw new NotFoundException("Task not found");

            var taskDto = _mapper.Map<TaskDto>(task);

            return taskDto;
        }

        public IEnumerable<TaskDto> GetAll()
        {
            var tasks = _dbContext.Tasks.ToList();

            var tasksDtos = _mapper.Map<List<TaskDto>>(tasks);

            return tasksDtos;
        }

        public int Create(CreateTaskDto taskDto)
        {
            var task = _mapper.Map<Task>(taskDto);

            _dbContext.Tasks.Add(task);
            _dbContext.SaveChanges();

            return task.Id;
        }
    }
}
