using MedicalCareApi.DTOs.User;
using MedicalCareApi.Models;
using Microsoft.AspNetCore.Identity.Data;

namespace MedicalCareApi.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto?> GetUserByIdAsync(int id);

        Task<UserDto?> RegisterUserAsync(CreateUserRequestDto request);
        Task<LoginResponseDto?> LoginAsync(LoginRequestDto request);
    }
}
