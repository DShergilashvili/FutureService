using FutureService.Api.Features.Todo.Commands;

namespace FutureService.Api.Features.Todo.Endpoints
{
    public class TodoWritesEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;

        public TodoWritesEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapPost("/api/TodoItems", async (TodoItemCreate dto) => await CreateTodoItem(dto))
                .WithName("CreateTodoItem")
                .WithDisplayName("TodoItems")
                .Produces<TodoItemCreate>()
                .Produces(500);
            return endpoints;
        }

        private async Task<IResult> CreateTodoItem(TodoItemCreate todoItem)
        {
            var command = new CreateTodoItem { NewTodoItem = todoItem };
            var result = await _mediator.Send(command);
            return Results.Ok(result);
        }

        public record TodoItemCreate(string Name, bool IsComplete);
    }  
}
