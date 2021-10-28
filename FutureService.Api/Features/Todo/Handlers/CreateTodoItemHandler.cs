using FutureService.Api.Features.Todo.Commands;
using FutureService.Api.Features.Todo.Endpoints;
using FutureService.Dal;
using FutureService.Domain.Models;

namespace FutureService.Api.Features.Todo.Handlers
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItem, TodoReadsEndpoint.TodoItem>
    {
        private readonly FutureServiceDbContext _ctx;
        private readonly IMapper _mapper;

        public CreateTodoItemHandler(FutureServiceDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<TodoReadsEndpoint.TodoItem> Handle(CreateTodoItem request, CancellationToken cancellationToken)
        {
            var todoItem = TodoItem.CreateTodoItem(request.NewTodoItem.Name, request.NewTodoItem.IsComplete);

            _ctx.TodoItems.Add(todoItem);

            await _ctx.SaveChangesAsync();

            return _mapper.Map<TodoReadsEndpoint.TodoItem>(todoItem);
        }
    }
}
