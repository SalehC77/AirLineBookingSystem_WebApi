using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
{
    public void Configure(EntityTypeBuilder<AppUser> builder)
    {
        builder.HasData(
            new AppUser { Id = 1, Username = "مستخدم02", Email = "user02@gmail.com", Password = "Seed_02#", Role = "مسافر", CreatedAt = new DateTime(2026, 1, 2, 0, 0, 0, DateTimeKind.Utc) },
            new AppUser { Id = 2, Username = "مستخدم01", Email = "user01@gmail.com", Password = "Seed_01#", Role = "مسافر", CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc) },
            new AppUser { Id = 3, Username = "مستخدم03", Email = "user03@gmail.com", Password = "Seed_03#", Role = "مسافر", CreatedAt = new DateTime(2026, 1, 3, 0, 0, 0, DateTimeKind.Utc) },
            new AppUser { Id = 4, Username = "مستخدم04", Email = "user04@gmail.com", Password = "Seed_04#", Role = "مسافر", CreatedAt = new DateTime(2026, 1, 4, 0, 0, 0, DateTimeKind.Utc) },
            new AppUser { Id = 5, Username = "مستخدم05", Email = "user05@gmail.com", Password = "Seed_05#", Role = "مسافر", CreatedAt = new DateTime(2026, 1, 5, 0, 0, 0, DateTimeKind.Utc) });
    }
}
