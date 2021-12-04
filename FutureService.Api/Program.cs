using FutureService.Api.Errors.ErrorPropertiesFactory;
using FutureService.Api.Errors.Exceptions;
using FutureService.Api.Extensions;
using Microsoft.AspNetCore.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder);
builder.RegisterModules();

var app = builder.Build();

app.UseExceptionHandler("/error");

app.ConfigureApplication();
app.MapEndpoints();


app.Run();
