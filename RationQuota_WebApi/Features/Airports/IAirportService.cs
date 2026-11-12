using AirLineBookingSystem_WebApi.Features.Airports.Dtos;

namespace AirLineBookingSystem_WebApi.Features.Airports;

public interface IAirportService
{
    Task<IEnumerable<AirportResponseDto>> GetAllAsync();
    Task<AirportResponseDto?> GetByIdAsync(int id);
    Task<AirportResponseDto> CreateAsync(AirportCreateDto dto);
    Task<AirportResponseDto?> UpdateAsync(int id, AirportUpdateDto dto);
    Task<bool> DeleteAsync(int id);
}
