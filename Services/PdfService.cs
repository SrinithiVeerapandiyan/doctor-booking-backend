namespace DoctorBookingAPI.Services
{
    public class PdfService
    {
        public byte[] GenerateAppointmentPdf(string content)
        {
            return System.Text.Encoding.UTF8.GetBytes(content);
        }
    }
}