using AirLineBookingSystem_WebApi.Models;
using System.ComponentModel.DataAnnotations;

public class User
{
    
    public int Id { get; set; }

    [Required]
    [MaxLength(50)]
    public string Username { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }

    [Required]
    public string Role { get; set; } = "Passenger";

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}