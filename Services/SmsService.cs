namespace DoctorBookingAPI.Services
{
    public class SmsService
    {
        public Task SendSmsAsync(string phoneNumber, string message)
        {
            return Task.CompletedTask;
        }
    }
}