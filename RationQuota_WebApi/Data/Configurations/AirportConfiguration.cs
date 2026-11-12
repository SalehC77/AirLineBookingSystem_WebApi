using AirLineBookingSystem_WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AirLineBookingSystem_WebApi.Data.Configurations;

public class AirportConfiguration : IEntityTypeConfiguration<Airport>
{
    public void Configure(EntityTypeBuilder<Airport> builder)
    {
        builder.HasData(
            new Airport { Id = 1001, Name = "مطار الملك خالد الدولي", Code = "RUH", City = "الرياض", Country = "المملكة العربية السعودية" },
            new Airport { Id = 1002, Name = "مطار الملك عبدالعزيز الدولي", Code = "JED", City = "جدة", Country = "المملكة العربية السعودية" },
            new Airport { Id = 1003, Name = "مطار الملك فهد الدولي", Code = "DMM", City = "الدمام", Country = "المملكة العربية السعودية" },
            new Airport { Id = 1004, Name = "مطار الأمير محمد بن عبدالعزيز الدولي", Code = "MED", City = "المدينة المنورة", Country = "المملكة العربية السعودية" },
            new Airport { Id = 1005, Name = "مطار أبها الدولي", Code = "AHB", City = "أبها", Country = "المملكة العربية السعودية" },
            new Airport { Id = 1006, Name = "مطار نيوم باي", Code = "NUM", City = "نيوم", Country = "المملكة العربية السعودية" });
    }
}
