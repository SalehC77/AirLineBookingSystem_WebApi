namespace AirLineBookingSystem_WebApi.Features.Airports.Dtos;

public class AirportResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public string? City { get; set; }
    public string Country { get; set; } = string.Empty;
}
