using AirLineBookingSystem_WebApi.Features.Passengers.Dtos;

namespace AirLineBookingSystem_WebApi.Features.Passengers
{
    public interface IPassengerService
    {
        Task<IEnumerable<PassengerResponseDto>> GetAllAsync();

        Task<PassengerResponseDto?> GetByIdAsync(int id);

        Task<PassengerResponseDto?> CreateAsync(PassengerCreateDto dto);

        Task<PassengerResponseDto?> UpdateAsync(int id, PassengerUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
