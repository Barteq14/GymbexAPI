using Gymbex.Application;
using Gymbex.Infrastructure;
using Gymbex.Infrastructure.Exceptions;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
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
builder.Services.AddEndpointsApiExplorer();

//ENABLE CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin", builder =>
    {
        builder
            .WithOrigins("https://localhost:7142") // Adresy URL, z których przyjmowane s¹ ¿¹dania.
            .AllowAnyMethod() // Metody HTTP, które s¹ dozwolone (np. GET, POST).
            .AllowAnyHeader() // Nag³ówki HTTP, które s¹ dozwolone.
            .AllowCredentials(); // W³¹cz autoryzacjê z plików cookie lub tokenów.
    });
});

builder.Services.AddControllers().
    AddNewtonsoftJson(option =>
    {
        option.SerializerSettings.ReferenceLoopHandling=Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    })
    .AddNewtonsoftJson(option =>
    {
        option.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });


var app = builder.Build();

app.UseCors("AllowSpecificOrigin");
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

app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();


app.Run();
