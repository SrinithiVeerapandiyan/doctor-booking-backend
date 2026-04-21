namespace DoctorBookingAPI.Models
{
    public class DoctorSchedule
    {
        public int DoctorId { get; set; }
        public DateTime AvailableDate { get; set; }
        public List<TimeSlot> Slots { get; set; } = new();
    }

    public class TimeSlot
    {
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public bool IsBooked { get; set; }
    }
}