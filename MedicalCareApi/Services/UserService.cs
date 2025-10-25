using MedicalCareApi.Data;
using MedicalCareApi.Models;
using MedicalCareApi.Helpers;
using Microsoft.EntityFrameworkCore;
using MedicalCareApi.DTOs.User;
using MedicalCareApi.Services.Interfaces;
using AutoMapper;

namespace MedicalCareApi.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IConfiguration config, IMapper mapper)
        {
            _context = context;
            _config = config;
            _mapper = mapper;
        }

        public async Task<UserDto?> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            return user == null ? null : _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto?> RegisterUserAsync(CreateUserRequestDto request)
        {
            var existingUser = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);
            if (existingUser != null)
            {
                return null;
            }
            var passwordHash = PasswordHelper.HashPassword(request.Password!);
            var newUser = new User
            {
                Name = request.Name,
                Email = request.Email!,
                Password = passwordHash,
                Role = "Patient"
            };
            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(newUser);
        }

        public async Task<LoginResponseDto?> LoginAsync(LoginRequestDto request)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);
            if (user == null || !PasswordHelper.VerifyPassword(request.Password, user.Password))
            {
                return null; // Invalid credentials
            }
            // Generate JWT token
            var tokenService = new TokenService(_config);
            var token = tokenService.GenerateToken(user);
            return new LoginResponseDto
            {
                Token = token,
                User = _mapper.Map<UserDto>(user)
            };
        }

    }
}
