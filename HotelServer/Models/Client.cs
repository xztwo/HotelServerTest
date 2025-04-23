using System.ComponentModel.DataAnnotations;

namespace HotelServer.Models
{
    public class Client
    {
        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; } // Фамилия

        [Required, MaxLength(50)]
        public string FirstName { get; set; } // Имя

        [MaxLength(50)]
        public string MiddleName { get; set; } // Отчество (необязательное)

        [Required, MaxLength(18)] // +7(XXX)XXX-XX-XX - 18 символов
        public string Phone { get; set; }

        [Required, MaxLength(4)]
        public string PassportSeries { get; set; } // Серия паспорта

        [Required, MaxLength(6)]
        public string PassportNumber { get; set; } // Номер паспорта

        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; } // Необязательное поле
    }
}