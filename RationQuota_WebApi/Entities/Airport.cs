using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Entities
{
    public class Airport
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(120)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(3, MinimumLength = 3)]
        public string Code { get; set; } = string.Empty;

        public string? City { get; set; }

        [Required]
        [MaxLength(100)]
        public string Country { get; set; } = string.Empty;
        public virtual ICollection<Flight> Flights { get; set; } = new List<Flight>();
    }
}
