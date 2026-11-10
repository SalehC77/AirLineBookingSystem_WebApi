
using AirLineBookingSystem_WebApi.Controllers.TicketBooking.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Controllers.TicketBooking;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors("CorsPolicy_AirLineBookingSystem")]
public class TicketBookingController : ControllerBase
{
    private readonly ITicketBookingService _bookingService;

    public TicketBookingController(ITicketBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    // Get All Bookings
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TicketBookingResponseDto>>> GetAll()
    {
        return Ok(await _bookingService.GetAllAsync());
    }

    // Get Booking By ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TicketBookingResponseDto>> GetById(int id)
    {
        var booking = await _bookingService.GetByIdAsync(id);

        return booking is null ? NotFound("Booking not found.") : Ok(booking);
    }

    // Create Booking
    [HttpPost]
    public async Task<ActionResult<TicketBookingResponseDto>> Create(
        TicketBookingCreateDto dto)
    {
        var booking = await _bookingService.CreateAsync(dto);

        if (booking is null)
            return BadRequest("Unable to create booking. Check the submitted data.");

        return CreatedAtAction(nameof(GetById), new { id = booking.Id }, booking);
    }

    // Update Booking
    [HttpPut("{id:int}")]
    public async Task<ActionResult<TicketBookingResponseDto>> Update(
        int id, TicketBookingUpdateDto dto)
    {
        var booking = await _bookingService.UpdateAsync(id, dto);

        return booking is null
            ? BadRequest("Booking was not found or update was rejected.")
            : Ok(booking);
    }

    // Delete (Cancel) Booking
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _bookingService.DeleteAsync(id);

        return deleted
            ? Ok("Booking cancelled successfully.")
            : NotFound();
    }
}
