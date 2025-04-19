using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelServer.Models
{
    public class ServiceRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автоинкремент Id
        public int Id { get; set; }

        [Required] // Обязательное поле
        [StringLength(10)] // Ограничение длины номера
        public string RoomNumber { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        public bool Completed { get; set; } = false;

        [StringLength(20)]
        public string Status { get; set; } = "Ожидает";

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Автоматическая дата создания
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}