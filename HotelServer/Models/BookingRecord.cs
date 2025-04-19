using System.ComponentModel.DataAnnotations;

namespace HotelServer.Models
{
    public class BookingRecord
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string RoomType { get; set; }
        public string CheckInDate { get; set; }
        public string CheckOutDate { get; set; }
    }
}