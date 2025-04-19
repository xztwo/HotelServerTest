using Grpc.Core;
using System.Threading.Tasks;
using HotelServer.Data;
using HotelServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelServer.Services
{
    // HotelServer/Services/BookingServiceImpl.cs
    public class BookingServiceImpl : BookingService.BookingServiceBase
    {
        private readonly AppDbContext _db;

        public BookingServiceImpl(AppDbContext db)
        {
            _db = db;
        }

        public override async Task<BookingResponse> BookRoom(BookingRequest request, ServerCallContext context)
        {
            var record = new BookingRecord
            {
                CustomerName = request.CustomerName,
                RoomType = request.RoomType,
                CheckInDate = request.CheckInDate,
                CheckOutDate = request.CheckOutDate
            };

            await _db.BookingRecords.AddAsync(record);
            await _db.SaveChangesAsync();

            return new BookingResponse { Success = true, Message = "Бронирование создано!" };
        }

        public override async Task<BookingListResponse> GetBookings(Empty request, ServerCallContext context)
        {
            var response = new BookingListResponse();
            var records = await _db.BookingRecords.ToListAsync();

            // Преобразуем записи в gRPC-сообщения
            response.Bookings.AddRange(records.Select(r => new global::HotelServer.Booking
            {
                CustomerName = r.CustomerName,
                RoomType = r.RoomType,
                CheckInDate = r.CheckInDate,
                CheckOutDate = r.CheckOutDate
            }));

            return response;
        }
    }
}