using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Features.Passengers.Dtos
{
    public class PassengerCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? PassportNumber { get; set; }

        public string? PhoneNumber { get; set; }

        [Range(1, int.MaxValue)]
        public int UserId { get; set; }
    }
}
