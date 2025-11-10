using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Cliente;
using Cliente.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Leer configuración
var apiBaseUrl = builder.Configuration["ApiSettings:BaseUrl"] ?? "http://localhost:5197";
Console.WriteLine($"🔧 API Base URL configurada: {apiBaseUrl}");

// IMPORTANTE: Agregar la barra al final
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(apiBaseUrl.TrimEnd('/') + "/")
});

// Registrar servicios
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IProductoService, ProductoService>();
builder.Services.AddScoped<IFacturaService, FacturaService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<AuthStateService>();

var app = builder.Build();

// Log para verificar
var httpClient = app.Services.GetRequiredService<HttpClient>();
Console.WriteLine($"✅ HttpClient BaseAddress: {httpClient.BaseAddress}");

await app.RunAsync();