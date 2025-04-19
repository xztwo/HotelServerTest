using HotelServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using HotelServer.Data;
using BCrypt.Net;
using HotelServer.Models;

var builder = WebApplication.CreateBuilder(args);

// Настройка Kestrel: поддержка и HTTP/1.1 (для REST и HTML), и HTTP/2 (для gRPC)
builder.WebHost.ConfigureKestrel(options =>
{
    // Порт 5207 — только для gRPC (HTTP/2)
    options.ListenAnyIP(5207, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });

    // Порт 5208 — для REST и HTML (HTTP/1.1)
    options.ListenAnyIP(5208, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
});

// Добавляем gRPC и контроллеры
builder.Services.AddGrpc();
builder.Services.AddControllers();

// Добавляем CORS (для HTML-страницы, отправляющей запросы)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Добавляем DbContext
builder.Services.AddDbContext<AppDbContext>();

// Регистрируем AuthServiceImpl с внедрением DbContext
builder.Services.AddGrpc().AddServiceOptions<AuthServiceImpl>(options =>
{ });

builder.Services.AddScoped<CleaningServiceImpl>();

var app = builder.Build();

// Обслуживаем HTML, CSS, JS из папки wwwroot
app.UseDefaultFiles(); // ищет index.html
app.UseStaticFiles();

// Применяем CORS
app.UseCors();

// Маршруты gRPC-сервисов
app.MapGrpcService<AuthServiceImpl>();
app.MapGrpcService<BookingServiceImpl>();
app.MapGrpcService<CleaningServiceImpl>();

// Маршрут для REST API-контроллеров
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    if (!db.Users.Any())
    {
        db.Users.Add(new User
        {
            Username = "admin",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password1"),
            Role = "admin"
        });

        db.Users.Add(new User
        {
            Username = "cleaner",
            PasswordHash = BCrypt.Net.BCrypt.HashPassword("password2"),
            Role = "cleaner"
        });

        await db.SaveChangesAsync();
    }
}
app.Run();
