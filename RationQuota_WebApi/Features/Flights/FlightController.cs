using AirLineBookingSystem_WebApi.Features.Flights.Dtos;
using AirLineBookingSystem_WebApi.Helpers.Enums;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace AirLineBookingSystem_WebApi.Features.Flights;

[Route("api/[controller]/[action]")]
[ApiController]
[EnableCors("CorsPolicy_AirLineBookingSystem")]
public class FlightController : ControllerBase
{
    private readonly IFlightService _flightService;

    public FlightController(IFlightService flightService)
    {
        _flightService = flightService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FlightResponseDto>>> GetAll(
        [FromQuery] int? departureAirportId,
        [FromQuery] int? arrivalAirportId,
        [FromQuery] FlightStatus? flightStatus,
        [FromQuery] DateTime? departureDate)
    {
        var flights = await _flightService.GetAllAsync(
            departureAirportId,
            arrivalAirportId,
            flightStatus,
            departureDate);

        return Ok(flights);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<FlightResponseDto>> GetById(int id)
    {
        var flight = await _flightService.GetByIdAsync(id);
        return flight is null ? NotFound("Flight not found.") : Ok(flight);
    }

    [HttpPost]
    public async Task<ActionResult<FlightResponseDto>> Create(FlightCreateDto dto)
    {
        var flight = await _flightService.CreateAsync(dto);
        if (flight is null)
        {
            return BadRequest("Departure or arrival airport does not exist.");
        }

        return CreatedAtAction(nameof(GetById), new { id = flight.Id }, flight);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<FlightResponseDto>> Update(int id, FlightUpdateDto dto)
    {
        var flight = await _flightService.UpdateAsync(id, dto);
        return flight is null
            ? NotFound("Flight was not found or an airport ID is invalid.")
            : Ok(flight);
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _flightService.DeleteAsync(id);
        return deleted ? Content("Flight deleted successfully.") : NotFound("Flight not found.");
    }
}
