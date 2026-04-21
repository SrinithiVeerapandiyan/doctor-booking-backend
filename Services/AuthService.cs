using DoctorBookingAPI.DTOs;
using DoctorBookingAPI.Helpers;
using DoctorBookingAPI.Models;
using DoctorBookingAPI.Repositories.Interfaces;
using DoctorBookingAPI.Services.Interfaces;

namespace DoctorBookingAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly JwtHelper _jwtHelper;

        public AuthService(IUserRepository userRepository, JwtHelper jwtHelper)
        {
            _userRepository = userRepository;
            _jwtHelper = jwtHelper;
        }

        public async Task<string> RegisterAsync(RegisterDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if (existingUser != null)
                throw new Exception("User already exists");

            var user = new User
            {
                FullName = dto.FullName,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Role = dto.Role,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return "User registered successfully";
        }

        public async Task<AuthResponseDto?> LoginAsync(LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                throw new Exception("Invalid email or password");

            return new AuthResponseDto
            {
                Token = _jwtHelper.GenerateToken(user),
                Email = user.Email,
                Role = user.Role,
                FullName = user.FullName
            };
        }
    }
}