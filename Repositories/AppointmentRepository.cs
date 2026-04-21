using DoctorBookingAPI.Data;
using DoctorBookingAPI.Models;
using DoctorBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorBookingAPI.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly AppDbContext _context;

        public AppointmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Appointment appointment)
        {
            await _context.Appointments.AddAsync(appointment);
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Doctor)
                .ToListAsync();
        }

        public async Task<Appointment?> GetByIdAsync(int id)
        {
            return await _context.Appointments
                .Include(a => a.User)
                .Include(a => a.Doctor)
                .Include(a => a.Availability)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<List<Appointment>> GetByUserIdAsync(int userId)
        {
            return await _context.Appointments
                .Include(a => a.Doctor)
                .Where(a => a.UserId == userId)
                .ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}