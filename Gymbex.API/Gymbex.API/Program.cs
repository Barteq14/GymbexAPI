using Gymbex.Application;
using Gymbex.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddControllers();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.MapControllers();

app.Run();
