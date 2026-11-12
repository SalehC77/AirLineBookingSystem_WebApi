using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Features.Airports.Dtos;

public class AirportCreateDto
{
    [Required]
    [MaxLength(120)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [StringLength(3, MinimumLength = 3)]
    public string Code { get; set; } = string.Empty;

    [MaxLength(100)]
    public string? City { get; set; }

    [Required]
    [MaxLength(100)]
    public string Country { get; set; } = string.Empty;
}
