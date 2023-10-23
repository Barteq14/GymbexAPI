using Blazored.LocalStorage;
using Gymbex.Blazor;
using Gymbex.Blazor.Components;
using Gymbex.Blazor.Security;
using Gymbex.Blazor.Services;
using Gymbex.Blazor.Utils;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;



var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");


builder.Services.AddScoped<ITokenStorage,HttpContextTokenStorage>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IActivityService, ActivityService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<Notification>();

builder.Services.AddHttpClient("MyApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7291/api");
});

var service = builder.Services.BuildServiceProvider();

var httpClient = service.GetRequiredService<IHttpClientFactory>().CreateClient("MyApiClient");

await builder.Build().RunAsync();
