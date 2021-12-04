using Microsoft.AspNetCore.Http.Features;

namespace FutureService.Api.Errors.ErrorPropertiesFactory
{
    public interface IErrorPropertiesFactory
    {
        IDictionary<string, object?> CreateCommonProperties();
    }

    public class ErrorPropertiesFactory : IErrorPropertiesFactory
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ErrorPropertiesFactory(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IDictionary<string, object?> CreateCommonProperties()
        {
            var originalRequestPath = _httpContextAccessor.HttpContext?
                .Features.Get<IHttpRequestFeature>()?
                .RawTarget;

            return new Dictionary<string, object?>
            {
                { "customProperty", "customPropertyValue"},
                { "RefRequestUrl", originalRequestPath }
            };
        }
    }
}
