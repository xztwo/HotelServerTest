using HotelServer.Services;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using HotelServer.Data;
using BCrypt.Net;
using HotelServer.Models;

var builder = WebApplication.CreateBuilder(args);

// ��������� Kestrel: ��������� � HTTP/1.1 (��� REST � HTML), � HTTP/2 (��� gRPC)
builder.WebHost.ConfigureKestrel(options =>
{
    // ���� 5207 � ������ ��� gRPC (HTTP/2)
    options.ListenAnyIP(5207, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http2;
    });

    // ���� 5208 � ��� REST � HTML (HTTP/1.1)
    options.ListenAnyIP(5208, listenOptions =>
    {
        listenOptions.Protocols = HttpProtocols.Http1;
    });
});

// ��������� gRPC � �����������
builder.Services.AddGrpc();
builder.Services.AddControllers();

// ��������� CORS (��� HTML-��������, ������������ �������)
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// ��������� DbContext
builder.Services.AddDbContext<AppDbContext>();

// ������������ AuthServiceImpl � ���������� DbContext
builder.Services.AddGrpc().AddServiceOptions<AuthServiceImpl>(options =>
{ });

builder.Services.AddScoped<CleaningServiceImpl>();

var app = builder.Build();

// ����������� HTML, CSS, JS �� ����� wwwroot
app.UseDefaultFiles(); // ���� index.html
app.UseStaticFiles();

// ��������� CORS
app.UseCors();

// �������� gRPC-��������
app.MapGrpcService<AuthServiceImpl>();
app.MapGrpcService<BookingServiceImpl>();
app.MapGrpcService<CleaningServiceImpl>();

// ������� ��� REST API-������������
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
