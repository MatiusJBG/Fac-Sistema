using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<AuthApiService>();

// Use a single HttpClient that targets the Server API (HTTPS port defined in Server launchSettings)
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7161/") });

await builder.Build().RunAsync();



