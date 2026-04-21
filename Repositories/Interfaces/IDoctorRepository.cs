using DoctorBookingAPI.Models;

namespace DoctorBookingAPI.Repositories.Interfaces
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllAsync();
        Task<Doctor?> GetByIdAsync(int id);
        Task AddAvailabilityAsync(DoctorAvailability availability);
        Task<List<DoctorAvailability>> GetAvailabilitiesByDoctorIdAsync(int doctorId);
        Task<DoctorAvailability?> GetAvailabilityByIdAsync(int availabilityId);
        Task SaveChangesAsync();
    }
}