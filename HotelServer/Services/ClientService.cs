using Grpc.Core;
using HotelServer.Data;
using HotelServer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HotelServer.Services
{
    public class ClientServiceImpl : ClientService.ClientServiceBase
    {
        private readonly AppDbContext _db;
        private readonly ILogger<ClientServiceImpl> _logger;

        public ClientServiceImpl(AppDbContext db, ILogger<ClientServiceImpl> logger)
        {
            _db = db;
            _logger = logger;
        }

        public override async Task<ClientResponse> AddClient(ClientRequest request, ServerCallContext context)
        {
            try
            {
                // Нормализация телефонного номера
                var normalizedPhone = NormalizePhone(request.Phone);

                // Валидация данных
                if (!IsValidPhone(normalizedPhone))
                    return new ClientResponse { Success = false, Message = "Неверный формат телефона. Используйте формат +7(XXX)XXX-XX-XX" };

                if (!IsValidPassport(request.PassportSeries, request.PassportNumber))
                    return new ClientResponse { Success = false, Message = "Неверные паспортные данные. Серия - 4 цифры, номер - 6 цифр" };

                if (!string.IsNullOrEmpty(request.Email) && !IsValidEmail(request.Email))
                    return new ClientResponse { Success = false, Message = "Неверный формат email" };

                // Проверка на существующего клиента
                if (await _db.Clients.AnyAsync(c =>
                    c.PassportSeries == request.PassportSeries &&
                    c.PassportNumber == request.PassportNumber))
                {
                    return new ClientResponse { Success = false, Message = "Клиент с такими паспортными данными уже существует" };
                }

                var client = new Client
                {
                    LastName = request.LastName.Trim(),
                    FirstName = request.FirstName.Trim(),
                    MiddleName = request.MiddleName?.Trim(),
                    Phone = normalizedPhone,
                    PassportSeries = request.PassportSeries,
                    PassportNumber = request.PassportNumber,
                    Email = request.Email?.Trim().ToLower()
                };

                await _db.Clients.AddAsync(client);
                await _db.SaveChangesAsync();

                return new ClientResponse
                {
                    Id = client.Id,
                    FullName = GetFullName(client),
                    Phone = FormatPhone(client.Phone), // Возвращаем в красивом формате
                    Passport = $"{client.PassportSeries} {client.PassportNumber}",
                    Email = client.Email,
                    Success = true,
                    Message = "Клиент успешно добавлен"
                };
            }
            catch (DbUpdateException dbEx)
            {
                _logger.LogError(dbEx, "Ошибка базы данных при добавлении клиента");
                return new ClientResponse { Success = false, Message = "Ошибка при сохранении данных" };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Неожиданная ошибка при добавлении клиента");
                return new ClientResponse { Success = false, Message = "Внутренняя ошибка сервера" };
            }
        }

        private string NormalizePhone(string phone)
        {
            // Удаляем все нецифровые символы, кроме +
            return string.Concat(phone.Where(c => char.IsDigit(c) || c == '+'));
        }

        private string FormatPhone(string phone)
        {
            // Форматируем номер для отображения: +7(XXX)XXX-XX-XX
            if (phone.Length == 12 && phone.StartsWith("+7"))
            {
                return $"+7({phone.Substring(2, 3)}){phone.Substring(5, 3)}-{phone.Substring(8, 2)}-{phone.Substring(10, 2)}";
            }
            return phone;
        }

        private bool IsValidPhone(string phone)
        {
            // Проверяем, что номер соответствует формату +7XXXXXXXXXX (11 цифр)
            var regex = new Regex(@"^\+7\d{10}$");
            return regex.IsMatch(phone);
        }

        private bool IsValidPassport(string series, string number)
        {
            return series?.Length == 4 &&
                   number?.Length == 6 &&
                   series.All(char.IsDigit) &&
                   number.All(char.IsDigit);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private string GetFullName(Client client)
        {
            return string.Join(" ", new[]
            {
                client.LastName,
                client.FirstName,
                client.MiddleName
            }.Where(s => !string.IsNullOrWhiteSpace(s)));
        }
    }
}