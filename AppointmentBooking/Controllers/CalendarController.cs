using Microsoft.AspNetCore.Mvc;
using AppointmentBooking.IServices;
using AppointmentBooking.Models;

[ApiController]
[Route("calendar")]
public class CalendarController(IAppointmentService appointmentService) : ControllerBase
{
    private readonly IAppointmentService _appointmentService = appointmentService;

    [HttpPost("query")]
    public async Task<IActionResult> QueryAvailableSlots([FromBody] QueryRequest request)
    {
        var availableSlots = await _appointmentService.GetAvailableSlotsAsync(request);
        return Ok(availableSlots);
    }
}