using FutureService.Api.Errors.ErrorPropertiesFactory;
using FutureService.Api.Errors.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace FutureService.Api.Features.Errors
{
    public class ExceptionEndPoint : IEndpoint
    {
        public IEndpointRouteBuilder RegisterRoutes(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/error", (IHttpContextAccessor httpContextAccessor, IErrorPropertiesFactory errorPropertiesFactory) =>
             ExceptionError(httpContextAccessor, errorPropertiesFactory))
                 .WithDisplayName("Exception")
                 .WithName("common Error Properties")
                 .Produces<ServiceException>()
                 .Produces(500);

            return endpoints;
        }

        private IResult ExceptionError(IHttpContextAccessor httpContextAccessor, IErrorPropertiesFactory errorPropertiesFactory)
        {

            Exception? exception = httpContextAccessor.HttpContext?
                .Features.Get<IExceptionHandlerFeature>()?
                .Error;

            var commonErrorProperties = errorPropertiesFactory.CreateCommonProperties();

            return exception is ServiceException e
                ? Results.Problem(
                    title: e.ErrorMessage,
                    statusCode: e.HttpStatusCode,
                    extensions: commonErrorProperties)
                : Results.Problem(
                    title: "An error occurred while processing your request.",
                    statusCode: StatusCodes.Status500InternalServerError,
                    extensions: commonErrorProperties);
        }
    }
}
