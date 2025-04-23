using System.ComponentModel.DataAnnotations;

namespace HotelServer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }  // Храним только хеш!
        public string Role { get; set; }         // "admin", "cleaner", "engineer" и т.д.
    }
}