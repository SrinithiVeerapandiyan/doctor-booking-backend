namespace DoctorBookingAPI.DTOs
{
    public class CreateAppointmentDto
    {
        public int UserId { get; set; }
        public int DoctorId { get; set; }
        public int AvailabilityId { get; set; }
        public string? Symptoms { get; set; }
        public string? Notes { get; set; }
    }

    public class AppointmentResponseDto
    {
        public int Id { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string DoctorName { get; set; } = string.Empty;
        public DateTime AppointmentDate { get; set; }
        public string StartTime { get; set; } = string.Empty;
        public string EndTime { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}