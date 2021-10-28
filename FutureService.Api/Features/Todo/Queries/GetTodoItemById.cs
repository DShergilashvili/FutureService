using FutureService.Api.Features.Todo.Endpoints;

namespace FutureService.Api.Features.Todo.Queries
{
    public class GetTodoItemById : IRequest<TodoReadsEndpoint.TodoItem>
    {
        public int TodoItemId { get; set; }
    }
}
