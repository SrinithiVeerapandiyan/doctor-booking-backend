using DoctorBookingAPI.Models;

namespace DoctorBookingAPI.Services.Interfaces
{
    public interface IDoctorService
    {
        Task<List<Doctor>> GetAllDoctorsAsync();
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task<string> AddAvailabilityAsync(DoctorAvailability availability);
        Task<List<DoctorAvailability>> GetAvailabilitiesAsync(int doctorId);
    }
}