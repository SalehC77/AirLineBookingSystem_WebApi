using AirLineBookingSystem_WebApi.Controllers.Ticket.Dtos;
using AirLineBookingSystem_WebApi.Controllers.User;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Controllers.Ticket
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [EnableCors("CorsPolicy_AirLineBookingSystem")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;

        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketResponseDto>>> GetAll()
        {
            return Ok(await _ticketService.GetAllAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TicketResponseDto>> GetById(int id)
        {
            var ticket = await _ticketService.GetByIdAsync(id);
            return ticket is null ? NotFound("Ticket not found.") : Ok(ticket);
        }

        [HttpPost]
        public async Task<ActionResult<TicketResponseDto>> Create(TicketCreateDto dto)
        {
            var ticket = await _ticketService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = ticket.Id }, ticket);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<TicketResponseDto>> Update(int id, TicketUpdateDto dto)
        {
            var ticket = await _ticketService.UpdateAsync(id, dto);
            return ticket is null ? NotFound("Ticket not found.") : Ok(ticket);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _ticketService.DeleteAsync(id);
            return deleted ? Content("Ticket deleted successfully.") : NotFound();
        }
    }
}