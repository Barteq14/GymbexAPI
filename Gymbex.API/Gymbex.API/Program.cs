using Gymbex.Application;
using Gymbex.Infrastructure;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddSwaggerGen(swagger =>
{
    swagger.EnableAnnotations();
    swagger.SwaggerDoc("v1", new OpenApiInfo()
    {
        Title = "Gymbex API",
        Version = "v1"
    });
});
builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI(swagger =>
{
    swagger.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});
app.MapControllers();

app.Run();
