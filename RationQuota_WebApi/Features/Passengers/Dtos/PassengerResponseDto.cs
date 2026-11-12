namespace AirLineBookingSystem_WebApi.Features.Passengers.Dtos
{
    public class PassengerResponseDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? PassportNumber { get; set; }

        public string? PhoneNumber { get; set; }

        public int UserId { get; set; }
    }
}
