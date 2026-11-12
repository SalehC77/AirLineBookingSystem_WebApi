
using AirLineBookingSystem_WebApi.Features.Passengers.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Features.Passengers;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors("CorsPolicy_AirLineBookingSystem")]
public class PassengerController : ControllerBase
{
    private readonly IPassengerService _passengerService;

    public PassengerController(IPassengerService passengerService)
    {
        _passengerService = passengerService;
    }

    // Get All Passengers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PassengerResponseDto>>> GetAll()
    {
        return Ok(await _passengerService.GetAllAsync());
    }

    // Get Passenger By ID
    [HttpGet("{id:int}")]
    public async Task<ActionResult<PassengerResponseDto>> GetById(int id)
    {
        var passenger = await _passengerService.GetByIdAsync(id);

        return passenger is null ? NotFound("Passenger not found.") : Ok(passenger);
    }

    // Create Passenger
    [HttpPost]
    public async Task<ActionResult<PassengerResponseDto>> Create(
        PassengerCreateDto dto)
    {
        var passenger = await _passengerService.CreateAsync(dto);

        if (passenger is null)
            return BadRequest("Invalid UserId. User does not exist.");

        return CreatedAtAction(
            nameof(GetById),
            new { id = passenger.Id },
            passenger);
    }

    // Update Passenger
    [HttpPut("{id:int}")]
    public async Task<ActionResult<PassengerResponseDto>> Update(
        int id, PassengerUpdateDto dto)
    {
        var passenger = await _passengerService.UpdateAsync(id, dto);

        return passenger is null
            ? BadRequest("Passenger was not found or UserId is invalid.")
            : Ok(passenger);
    }

    // Delete Passenger
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _passengerService.DeleteAsync(id);

        return deleted
            ? Content("Passenger deleted successfully.")
            : NotFound();
    }
}
