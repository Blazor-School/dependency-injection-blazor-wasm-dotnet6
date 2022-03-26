using DependencyInjection;
using DependencyInjection.Data.ServiceScope;
using DependencyInjection.Data.ServiceWithInterface;
using DependencyInjection.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();
builder.Services.AddTransient<IServiceInterface, ServiceWithInterface>();
builder.Services.AddTransient<ServiceWithCustomData>(serviceProvider => new("Blazor School"));
builder.Services.AddTransient<DependentService>(serviceProvider => new(serviceProvider.GetRequiredService<ServiceWithCustomData>()));

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
