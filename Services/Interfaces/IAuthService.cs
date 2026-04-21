using DoctorBookingAPI.DTOs;

namespace DoctorBookingAPI.Services.Interfaces
{
    public interface IAuthService
    {
        Task<string> RegisterAsync(RegisterDto dto);
        Task<AuthResponseDto?> LoginAsync(LoginDto dto);
    }
}