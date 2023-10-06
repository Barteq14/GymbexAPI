using Gymbex.Application;
using Gymbex.Infrastructure;
using Gymbex.Infrastructure.Exceptions;
using Microsoft.OpenApi.Models;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

//swagger
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.EnableAnnotations();
    swagger.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Gymbex API",
        Version = "v1"
    });
});

//serilog
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .WriteTo.Console()
        .WriteTo.File("logs/logs.txt");
});

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseReDoc(r =>
{
    r.DocumentTitle = "Gymbex API";
    r.RoutePrefix = "docs";
    r.SpecUrl = "/swagger/v1/swagger.json";
});
app.UseSwaggerUI(swagger =>
{
    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();

app.Run();
