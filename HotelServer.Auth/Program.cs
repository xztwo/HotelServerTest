using HotelServer.Auth.Services;
using HotelServer.Auth.Data;
using Microsoft.EntityFrameworkCore;
using HotelServer.Auth.Models;

var builder = WebApplication.CreateBuilder(args);

// ������������ ��
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection")));

// gRPC
builder.Services.AddGrpc();

var app = builder.Build();

// ���������� �������� � ������������� ��
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AuthDbContext>();

    // ������� ��, ���� �� ����������
    await db.Database.EnsureCreatedAsync();

    // ��������� �������� ������, ���� ������� �����
    if (!db.Users.Any())
    {
        db.Users.AddRange(
            new User
            {
                Username = "admin",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                Role = "admin"
            },
            new User
            {
                Username = "cleaner",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("cleaner123"),
                Role = "cleaner"
            }
        );
        await db.SaveChangesAsync();
    }
}

app.MapGrpcService<AuthServiceImpl>();
app.Run();