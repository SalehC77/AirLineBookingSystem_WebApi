using System.ComponentModel.DataAnnotations;

namespace AirLineBookingSystem_WebApi.Controllers.User.Dtos;

public class UserCreateDto
{
    [Required]
    [MaxLength(50)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; } = string.Empty;

    public string Role { get; set; } = "Passenger";
}