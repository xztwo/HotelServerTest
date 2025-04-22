using HotelServer.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelServer.Auth.Data
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Username)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.PasswordHash)
                    .IsRequired()
                    .HasMaxLength(255);
                entity.Property(u => u.Role)
                    .IsRequired()
                    .HasMaxLength(20);
                
                entity.HasIndex(u => u.Username)
                    .IsUnique();
            });
        }
    }
} 