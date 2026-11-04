using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AirLineBookingSystem_WebApi.Entities
{
    public class Passenger
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Gender { get; set; }

        public string? Nationality { get; set; }

        public string? PassportNumber { get; set; }

        public string? PhoneNumber { get; set; }

        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        // Navigation Properties
        public AppUser? User { get; set; }

        public ICollection<TicketBooking> Tickets { get; set; } = new List<TicketBooking>();
    }
}
