using Microsoft.EntityFrameworkCore;
using EventModel = Evenza.Domain.Event.Event;
using UserModel = Evenza.Domain.User.User;

namespace Evenza.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<EventModel> Events { get; set; }
    public DbSet<UserModel> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<UserModel>(builder =>
        {
             builder.Property(u => u.Email)
                 .HasMaxLength(50)
                 .IsRequired();
             builder.Property(u => u.UserName)
                 .HasMaxLength(40)
                 .IsRequired();
             builder.Property(u => u.Password)
                 .HasMaxLength(20)
                 .IsRequired();
        });
        modelBuilder.Entity<UserModel>()
            .HasKey(u => u.Id);
        modelBuilder.Entity<UserModel>()
            .HasIndex(r => r.Email)
            .IsUnique();
        
        modelBuilder.Entity<EventModel>(builder =>
        {
            builder.Property(u => u.Name)
                .HasMaxLength(50)
                .IsRequired();
        });
        modelBuilder.Entity<EventModel>()
            .HasKey(u => u.Id);
    }
}