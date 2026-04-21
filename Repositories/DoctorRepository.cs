using DoctorBookingAPI.Data;
using DoctorBookingAPI.Models;
using DoctorBookingAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DoctorBookingAPI.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly AppDbContext _context;

        public DoctorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
            return await _context.Doctors.ToListAsync();
        }

        public async Task<Doctor?> GetByIdAsync(int id)
        {
            return await _context.Doctors.FindAsync(id);
        }

        public async Task AddAvailabilityAsync(DoctorAvailability availability)
        {
            await _context.DoctorAvailabilities.AddAsync(availability);
        }

        public async Task<List<DoctorAvailability>> GetAvailabilitiesByDoctorIdAsync(int doctorId)
        {
            return await _context.DoctorAvailabilities
                .Where(x => x.DoctorId == doctorId)
                .ToListAsync();
        }

        public async Task<DoctorAvailability?> GetAvailabilityByIdAsync(int availabilityId)
        {
            return await _context.DoctorAvailabilities
                .FirstOrDefaultAsync(x => x.Id == availabilityId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}