using FutureService.Api.Features.Todo.Endpoints;
using FutureService.Api.Features.Todo.Queries;
using FutureService.Dal;

namespace FutureService.Api.Features.Todo.Handlers
{
    public class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItems, List<TodoReadsEndpoint.TodoItem>>
    {
        private readonly FutureServiceDbContext _ctx;
        private readonly IMapper _mapper;
        public GetAllTodoItemsHandler(FutureServiceDbContext ctx, IMapper mapper)
        {
            _ctx = ctx;
            _mapper = mapper;
        }
        public async Task<List<TodoReadsEndpoint.TodoItem>> Handle(GetAllTodoItems request, CancellationToken cancellationToken)
        {
            var todoItems = await _ctx.TodoItems.ToListAsync();

            return _mapper.Map<List<TodoReadsEndpoint.TodoItem>>(todoItems);
        }
    }
}
