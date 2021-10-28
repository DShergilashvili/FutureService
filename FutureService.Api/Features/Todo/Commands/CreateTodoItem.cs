using FutureService.Api.Features.Todo.Endpoints;

namespace FutureService.Api.Features.Todo.Commands
{
    public class CreateTodoItem : IRequest<TodoReadsEndpoint.TodoItem>
    {
        public TodoWritesEndpoint.TodoItemCreate NewTodoItem { get; set; }
    }
}
