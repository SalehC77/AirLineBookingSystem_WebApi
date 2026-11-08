using AirLineBookingSystem_WebApi.Controllers.Ticket.Dtos;

namespace AirLineBookingSystem_WebApi.Controllers.User
{
    public interface ITicketService
    {
        Task<IEnumerable<TicketResponseDto>> GetAllAsync();

        Task<TicketResponseDto?> GetByIdAsync(int id);

        Task<TicketResponseDto> CreateAsync(TicketCreateDto dto);

        Task<TicketResponseDto?> UpdateAsync(int id, TicketUpdateDto dto);

        Task<bool> DeleteAsync(int id);
    }
}
