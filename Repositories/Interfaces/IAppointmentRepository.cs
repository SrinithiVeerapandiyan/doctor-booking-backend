using DoctorBookingAPI.Models;

namespace DoctorBookingAPI.Repositories.Interfaces
{
    public interface IAppointmentRepository
    {
        Task AddAsync(Appointment appointment);
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment?> GetByIdAsync(int id);
        Task<List<Appointment>> GetByUserIdAsync(int userId);
        Task SaveChangesAsync();
    }
}