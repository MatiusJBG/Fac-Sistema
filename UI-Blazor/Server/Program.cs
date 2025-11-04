using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Agregar la conexión a la base de datos
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection"))
    ));

// 2️⃣ Agregar servicios MVC y Razor Pages
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

// 3️⃣ Agregar OpenAPI (Swagger u OpenAPI minimal)
builder.Services.AddOpenApi();

builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirCliente", policy =>
    {
        // Permitir el origen donde se ejecuta el cliente Blazor (ajustado a Client launchSettings)
        policy.WithOrigins("http://localhost:5001", "https://localhost:5001")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// 4️⃣ Configurar el pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Aplicar CORS después de construir la app y después de UseRouting
app.UseCors("PermitirCliente");

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

// 5️⃣ Ejecutar la aplicación
app.Run();