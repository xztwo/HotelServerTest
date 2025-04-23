using Grpc.Core;
using HotelServer.Data;
using HotelServer.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HotelServer.Services
{
    public class CleaningServiceImpl : CleaningService.CleaningServiceBase
    {
        private readonly AppDbContext _db;

        // Внедряем зависимость AppDbContext через конструктор
        public CleaningServiceImpl(AppDbContext db)
        {
            _db = db;
        }

        public override async Task<CleaningRequestList> GetCleaningRequests(Empty request, ServerCallContext context)
        {
            var list = new CleaningRequestList();

            // Получаем заявки из БД, включая только незавершённые
            var requests = await _db.ServiceRequests
                .Where(r => !r.Completed)
                .OrderBy(r => r.CreatedAt)
                .ToListAsync();

            foreach (var req in requests)
            {
                list.Requests.Add(new CleaningRequest
                {
                    Id = req.Id,
                    RoomNumber = req.RoomNumber,
                    Category = req.Description,
                    Completed = req.Completed
                });
            }

            return list;
        }

        public override async Task<Ack> CompleteRequest(CleaningRequestId request, ServerCallContext context)
        {
            // Находим заявку в БД
            var item = await _db.ServiceRequests
                .FirstOrDefaultAsync(r => r.Id == request.Id);

            if (item != null)
            {
                // Обновляем статус
                item.Completed = true;
                item.Status = "Выполнено";

                // Сохраняем изменения
                await _db.SaveChangesAsync();

                return new Ack
                {
                    Success = true,
                    Message = "Заявка отмечена как выполненная."
                };
            }

            return new Ack
            {
                Success = false,
                Message = "Заявка не найдена."
            };
        }
    }
}