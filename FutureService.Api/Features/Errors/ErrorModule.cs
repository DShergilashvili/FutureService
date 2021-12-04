using FutureService.Api.Errors.ErrorPropertiesFactory;

namespace FutureService.Api.Features.Errors
{
    public class ErrorModule : IModule
    {
        public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints)
        {
            new ExceptionEndPoint().RegisterRoutes(endpoints);

            return endpoints;
        }

        public WebApplicationBuilder RegisterModule(WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddScoped<IErrorPropertiesFactory, ErrorPropertiesFactory>();

            return builder;
        }
    }
}
