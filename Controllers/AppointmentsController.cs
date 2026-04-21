using DoctorBookingAPI.DTOs;
using DoctorBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Book(CreateAppointmentDto dto)
        {
            var result = await _appointmentService.BookAppointmentAsync(dto);
            return Ok(new { message = result });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _appointmentService.GetAllAppointmentsAsync();
            return Ok(result);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result = await _appointmentService.GetAppointmentsByUserIdAsync(userId);
            return Ok(result);
        }
    }
}