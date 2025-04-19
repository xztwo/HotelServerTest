using HotelServer.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelServer.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<BookingRecord> BookingRecords { get; set; }

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
        }
    }
}