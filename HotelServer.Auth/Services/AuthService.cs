using Grpc.Core;
using HotelServer.Auth;
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using HotelServer.Auth.Data;

namespace HotelServer.Auth.Services
{
    public class AuthServiceImpl : AuthService.AuthServiceBase
    {
        private readonly AuthDbContext _db;

        public AuthServiceImpl(AuthDbContext db)
        {
            _db = db;
        }

        public override async Task<LoginResponse> Login(LoginRequest request, ServerCallContext context)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            {
                return new LoginResponse { Success = false, Message = "Неверный логин или пароль." };
            }

            return new LoginResponse
            {
                Success = true,
                Message = $"Добро пожаловать, {user.Role}!",
                Role = user.Role
            };
        }
    }
}