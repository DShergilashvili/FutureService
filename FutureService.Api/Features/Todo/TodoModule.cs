using FutureService.Api.Features.Todo.Endpoints;

namespace FutureService.Api.Features.Todo
{
    public class TodoModule : IModule
    {
        private IMediator _mediator;
        private IMapper _mapper;
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new TodoReadsEndpoint(_mediator).RegisterRoutes(endpoints);
            new TodoWritesEndpoint(_mediator).RegisterRoutes(endpoints);
            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            var provider = builder.Services.BuildServiceProvider();
            _mediator = provider.GetRequiredService<IMediator>();
            _mapper = provider.GetRequiredService<IMapper>();
            return builder;
        }
    }
}
