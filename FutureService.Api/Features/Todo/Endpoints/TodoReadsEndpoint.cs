using FutureService.Api.Errors.Exceptions;
using FutureService.Api.Features.Todo.Queries;

namespace FutureService.Api.Features.Todo.Endpoints
{
    public class TodoReadsEndpoint : IEndpoint
    {
        private readonly IMediator _mediator;
        public TodoReadsEndpoint(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/api/TodoItems", async () => await GetAllTodoItems())
                .WithDisplayName("TodoItems")
                .WithName("Get all TodoItems")
                .Produces<List<TodoItem>>()
                .Produces(500);

            endpoints.MapGet("/api/TodoItems/{id}", async (int id) => await GetTodoItemById(id))
                .WithDisplayName("TodoItems")
                .WithName("GetTodoItemById")
                .Produces<TodoItem>()
                .Produces(404)
                .Produces(500);
            return endpoints;
        }

        private async Task<IResult> GetAllTodoItems()
        {
            var result = await _mediator.Send(new GetAllTodoItems());
            return Results.Ok(result);
        }

        private async Task<IResult> GetTodoItemById(int id)
        {
            var result = await _mediator.Send(new GetTodoItemById { TodoItemId = id});
            if (result is null)
                return Results.NotFound();

            return Results.Ok(result);
        }

        public record TodoItem
        {
            public long Id { get; set; }
            public string? Name { get; set; }
            public bool IsComplete { get; set; }
        }

    }
}
