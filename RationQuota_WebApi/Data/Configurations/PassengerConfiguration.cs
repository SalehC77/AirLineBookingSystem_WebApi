using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
{
    public void Configure(EntityTypeBuilder<Passenger> builder)
    {
        builder.HasData(
            new Passenger { Id = 1, FirstName = "أحمد", LastName = "العمري", DateOfBirth = new DateTime(1990, 4, 12), Gender = "ذكر", Nationality = "المملكة العربية السعودية", PassportNumber = "SEED-PASS-001", PhoneNumber = "555-0101", UserId = 1 },
            new Passenger { Id = 2, FirstName = "فاطمة", LastName = "القحطاني", DateOfBirth = new DateTime(1988, 8, 23), Gender = "أنثى", Nationality = "المملكة العربية السعودية", PassportNumber = "SEED-PASS-002", PhoneNumber = "555-0102", UserId = 2 },
            new Passenger { Id = 3, FirstName = "خالد", LastName = "الحربي", DateOfBirth = new DateTime(1995, 2, 5), Gender = "ذكر", Nationality = "المملكة العربية السعودية", PassportNumber = "SEED-PASS-003", PhoneNumber = "555-0103", UserId = 3 },
            new Passenger { Id = 4, FirstName = "نورة", LastName = "العتيبي", DateOfBirth = new DateTime(1992, 11, 17), Gender = "أنثى", Nationality = "المملكة العربية السعودية", PassportNumber = "SEED-PASS-004", PhoneNumber = "555-0104", UserId = 4 },
            new Passenger { Id = 5, FirstName = "عبدالله", LastName = "الشهري", DateOfBirth = new DateTime(1985, 6, 30), Gender = "ذكر", Nationality = "المملكة العربية السعودية", PassportNumber = "SEED-PASS-005", PhoneNumber = "555-0105", UserId = 5 });
    }
}
