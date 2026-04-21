using DoctorBookingAPI.Models;
using DoctorBookingAPI.Repositories.Interfaces;
using DoctorBookingAPI.Services.Interfaces;

namespace DoctorBookingAPI.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _doctorRepository;

        public DoctorService(IDoctorRepository doctorRepository)
        {
            _doctorRepository = doctorRepository;
        }

        public async Task<List<Doctor>> GetAllDoctorsAsync()
        {
            return await _doctorRepository.GetAllAsync();
        }

        public async Task<Doctor?> GetDoctorByIdAsync(int id)
        {
            return await _doctorRepository.GetByIdAsync(id);
        }

        public async Task<string> AddAvailabilityAsync(DoctorAvailability availability)
        {
            await _doctorRepository.AddAvailabilityAsync(availability);
            await _doctorRepository.SaveChangesAsync();
            return "Availability added successfully";
        }

        public async Task<List<DoctorAvailability>> GetAvailabilitiesAsync(int doctorId)
        {
            return await _doctorRepository.GetAvailabilitiesByDoctorIdAsync(doctorId);
        }
    }
}