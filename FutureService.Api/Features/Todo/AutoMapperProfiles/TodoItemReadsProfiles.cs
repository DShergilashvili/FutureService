using FutureService.Api.Features.Todo.Endpoints;
using FutureService.Domain.Models;

namespace FutureService.Api.Features.Todo.AutoMapperProfiles
{
    public class TodoItemReadsProfiles : Profile
    {
        public TodoItemReadsProfiles()
        {
            CreateMap<TodoItem, TodoReadsEndpoint.TodoItem>();
        }
    }
}
