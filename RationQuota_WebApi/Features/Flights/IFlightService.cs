using AirLineBookingSystem_WebApi.Features.Flights.Dtos;
using AirLineBookingSystem_WebApi.Helpers.Enums;

namespace AirLineBookingSystem_WebApi.Features.Flights;

public interface IFlightService
{
    Task<IEnumerable<FlightResponseDto>> GetAllAsync(
        int? departureAirportId,
        int? arrivalAirportId,
        FlightStatus? flightStatus,
        DateTime? departureDate);
    Task<FlightResponseDto?> GetByIdAsync(int id);
    Task<FlightResponseDto?> CreateAsync(FlightCreateDto dto);
    Task<FlightResponseDto?> UpdateAsync(int id, FlightUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
