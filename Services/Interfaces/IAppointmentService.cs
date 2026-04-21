using DoctorBookingAPI.DTOs;

namespace DoctorBookingAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<string> BookAppointmentAsync(CreateAppointmentDto dto);
        Task<List<AppointmentResponseDto>> GetAllAppointmentsAsync();
        Task<List<AppointmentResponseDto>> GetAppointmentsByUserIdAsync(int userId);
    }
}