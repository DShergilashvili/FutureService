using FutureService.Api.Features.Todo.Endpoints;
using FutureService.Api.Features.Todo.Queries;
using FutureService.Dal;

namespace FutureService.Api.Features.Todo.Handlers
{
    public class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemById, TodoReadsEndpoint.TodoItem>
    {
        private readonly FutureServiceDbContext _ctx;
        private readonly IMapper _mapper;

        public GetTodoItemByIdHandler(FutureServiceDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<TodoReadsEndpoint.TodoItem> Handle(GetTodoItemById request, CancellationToken cancellationToken)
        {
            var todoItem = await _ctx.TodoItems.FirstOrDefaultAsync(b => b.Id == request.TodoItemId);
            return _mapper.Map<TodoReadsEndpoint.TodoItem>(todoItem);
        }
    }
}
