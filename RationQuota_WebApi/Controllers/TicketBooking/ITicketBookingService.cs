using AirLineBookingSystem_WebApi.Controllers.TicketBooking.Dtos;

namespace AirLineBookingSystem_WebApi.Controllers.TicketBooking
{
    public interface ITicketBookingService
    {
        Task<IEnumerable<TicketBookingResponseDto>> GetAllAsync();

        Task<TicketBookingResponseDto?> GetByIdAsync(int id);

        Task<TicketBookingResponseDto?> CreateAsync(TicketBookingCreateDto dto);

        Task<TicketBookingResponseDto?> UpdateAsync(int id, TicketBookingUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
