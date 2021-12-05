using FutureService.Api.Localizer;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

namespace FutureService.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        public static WebApplication ConfigureApplication(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandler("/error");

            var options = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(new CultureInfo("en-US"))
            };

            app.UseRequestLocalization(options);
            app.UseStaticFiles();
            app.UseMiddleware<LocalizationMiddleware>();

            app.UseHttpsRedirection();

            return app;
        }        
    }
}
