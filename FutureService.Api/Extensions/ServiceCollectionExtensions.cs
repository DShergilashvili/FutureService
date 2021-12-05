using FutureService.Api.Localizer;
using FutureService.Dal;
using Microsoft.Extensions.Localization;

namespace FutureService.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services,
            WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSingleton<LocalizationMiddleware>();
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSingleton<IStringLocalizerFactory, JsonStringLocalizerFactory>();

            builder.Services.AddSwaggerGen(c => 
            {
                c.SwaggerDoc("v1", new() { Title = builder.Environment.ApplicationName, Version="v1"});
                c.TagActionsBy(ta =>
                {
                    return new List<string> { ta.ActionDescriptor.DisplayName! };
                });
            });

            builder.Services.AddDbContext<FutureServiceDbContext>(opt =>
               opt.UseSqlite(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddMediatR(typeof(Program));
            builder.Services.AddAutoMapper(typeof(Program));
            return services;
        }
    }
}
