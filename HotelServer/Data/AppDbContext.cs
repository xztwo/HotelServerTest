using HotelServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelServer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<BookingRecord> BookingRecords { get; set; }
        public DbSet<Client> Clients { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=hoteldb;Username=postgres;Password=Pwt4950z");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Конфигурация BookingRecord
            modelBuilder.Entity<BookingRecord>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.Property(b => b.CustomerName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(b => b.RoomType)
                    .IsRequired()
                    .HasMaxLength(50);

                // Изменено: храним как строку (varchar) вместо date
                entity.Property(b => b.CheckInDate)
                    .IsRequired()
                    .HasColumnType("varchar(20)"); // Формат: "YYYY-MM-DD"

                entity.Property(b => b.CheckOutDate)
                    .IsRequired()
                    .HasColumnType("varchar(20)");
            });

            // Конфигурация User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u => u.PasswordHash).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Role).IsRequired().HasMaxLength(20);
            });

            // Конфигурация ServiceRequest
            modelBuilder.Entity<ServiceRequest>().HasKey(sr => sr.Id);

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.LastName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(c => c.MiddleName).HasMaxLength(50);

                entity.Property(c => c.Phone)
                    .IsRequired()
                    .HasMaxLength(18)
                    .HasConversion(
                        v => v.Replace(" ", ""), // Удаляем пробелы при сохранении
                        v => FormatPhoneNumber(v)); // Форматируем при чтении

                entity.Property(c => c.PassportSeries)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsFixedLength();

                entity.Property(c => c.PassportNumber)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsFixedLength();

                entity.Property(c => c.Email)
                    .HasMaxLength(100);
            });

        }
        private static string FormatPhoneNumber(string phone)
        {
            // Форматирование +7XXXXXXXXXX в +7(XXX)XXX-XX-XX
            if (phone.Length == 12 && phone.StartsWith("+7"))
                return $"+7({phone.Substring(2, 3)}){phone.Substring(5, 3)}-{phone.Substring(8, 2)}-{phone.Substring(10, 2)}";
            return phone;
        }
    }
}