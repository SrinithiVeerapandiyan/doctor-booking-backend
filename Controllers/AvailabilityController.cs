using DoctorBookingAPI.Models;
using DoctorBookingAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DoctorBookingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailabilityController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public AvailabilityController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<IActionResult> AddAvailability(DoctorAvailability availability)
        {
            var result = await _doctorService.AddAvailabilityAsync(availability);
            return Ok(new { message = result });
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetByDoctorId(int doctorId)
        {
            var availabilities = await _doctorService.GetAvailabilitiesAsync(doctorId);
            return Ok(availabilities);
        }
    }
}