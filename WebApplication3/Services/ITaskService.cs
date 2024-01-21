using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface ITaskService
    {
        int Create(CreateTaskDto taskDto);
        IEnumerable<TaskDto> GetAll();
        TaskDto GetById(int id);
        bool Delete(int id);
        bool Update(int id, UpdateTaskDto dto);
    }
}