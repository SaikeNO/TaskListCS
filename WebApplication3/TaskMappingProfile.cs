using AutoMapper;
using WebApplication3.Models;
using Task = WebApplication3.Entities.Task;

namespace WebApplication3
{
    public class TaskMappingProfile: Profile
    {
        public TaskMappingProfile()
        {
            CreateMap<Task, TaskDto>();

            CreateMap<CreateTaskDto, Task>();
        }
    }
}
