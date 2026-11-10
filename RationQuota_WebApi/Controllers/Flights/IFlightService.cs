using AirLineBookingSystem_WebApi.Controllers.Flights.Dtos;

namespace AirLineBookingSystem_WebApi.Controllers.Flights;

public interface IFlightService
{
    Task<IEnumerable<FlightResponseDto>> GetAllAsync();
    Task<FlightResponseDto?> GetByIdAsync(int id);
    Task<FlightResponseDto> CreateAsync(FlightCreateDto dto);
    Task<FlightResponseDto?> UpdateAsync(int id, FlightUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
