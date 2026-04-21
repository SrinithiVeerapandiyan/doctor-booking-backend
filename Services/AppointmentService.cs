using DoctorBookingAPI.DTOs;
using DoctorBookingAPI.Models;
using DoctorBookingAPI.Repositories.Interfaces;
using DoctorBookingAPI.Services.Interfaces;

namespace DoctorBookingAPI.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _appointmentRepository;
        private readonly IDoctorRepository _doctorRepository;
        private readonly IUserRepository _userRepository;

        public AppointmentService(
            IAppointmentRepository appointmentRepository,
            IDoctorRepository doctorRepository,
            IUserRepository userRepository)
        {
            _appointmentRepository = appointmentRepository;
            _doctorRepository = doctorRepository;
            _userRepository = userRepository;
        }

        public async Task<string> BookAppointmentAsync(CreateAppointmentDto dto)
        {
            var user = await _userRepository.GetByIdAsync(dto.UserId);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            var doctor = await _doctorRepository.GetByIdAsync(dto.DoctorId);
            if (doctor == null)
            {
                throw new Exception("Doctor not found");
            }

            var availability = await _doctorRepository.GetAvailabilityByIdAsync(dto.AvailabilityId);
            if (availability == null)
            {
                throw new Exception("Availability not found");
            }

            if (availability.IsBooked)
            {
                throw new Exception("Slot already booked");
            }

            var appointment = new Appointment
            {
                UserId = dto.UserId,
                DoctorId = dto.DoctorId,
                AvailabilityId = dto.AvailabilityId,
                AppointmentDate = availability.AvailableDate,
                StartTime = availability.StartTime,
                EndTime = availability.EndTime,
                Symptoms = dto.Symptoms,
                Notes = dto.Notes,
                Status = "Pending"
            };

            availability.IsBooked = true;

            await _appointmentRepository.AddAsync(appointment);
            await _appointmentRepository.SaveChangesAsync();
            await _doctorRepository.SaveChangesAsync();

            return "Appointment booked successfully";
        }

        public async Task<List<AppointmentResponseDto>> GetAllAppointmentsAsync()
        {
            var appointments = await _appointmentRepository.GetAllAsync();

            return appointments.Select(a => new AppointmentResponseDto
            {
                Id = a.Id,
                PatientName = a.User?.FullName ?? "",
                DoctorName = a.Doctor?.FullName ?? "",
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime.ToString(@"hh\:mm"),
                EndTime = a.EndTime.ToString(@"hh\:mm"),
                Status = a.Status
            }).ToList();
        }

        public async Task<List<AppointmentResponseDto>> GetAppointmentsByUserIdAsync(int userId)
        {
            var appointments = await _appointmentRepository.GetByUserIdAsync(userId);

            return appointments.Select(a => new AppointmentResponseDto
            {
                Id = a.Id,
                PatientName = "",
                DoctorName = a.Doctor?.FullName ?? "",
                AppointmentDate = a.AppointmentDate,
                StartTime = a.StartTime.ToString(@"hh\:mm"),
                EndTime = a.EndTime.ToString(@"hh\:mm"),
                Status = a.Status
            }).ToList();
        }
    }
}