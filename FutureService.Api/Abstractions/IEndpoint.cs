namespace FutureService.Api.Abstractions
{
    public interface IEndpoint
    {
        IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints);
    }
}
