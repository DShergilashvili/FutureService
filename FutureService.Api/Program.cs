using FutureService.Api.Extensions;
using FutureService.Api.Localizer;
using Microsoft.AspNetCore.Localization;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder);
builder.RegisterModules();

var app = builder.Build();
app.ConfigureApplication();
app.MapEndpoints();


app.Run();
