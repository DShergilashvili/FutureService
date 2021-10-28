using FutureService.Api.Features.Todo.Endpoints;

namespace FutureService.Api.Features.Todo.Queries
{
    public class GetAllTodoItems : IRequest<List<TodoReadsEndpoint.TodoItem>>
    {
    }
}
