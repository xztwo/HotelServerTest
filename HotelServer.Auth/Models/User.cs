using System.ComponentModel.DataAnnotations;

namespace HotelServer.Auth.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Username { get; set; }
        public required string PasswordHash { get; set; }  // Храним только хеш!
        public required string Role { get; set; }         // "admin", "cleaner", "engineer" и т.д.
    }
}