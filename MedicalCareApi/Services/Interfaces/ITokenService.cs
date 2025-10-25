using MedicalCareApi.Models;

namespace MedicalCareApi.Services.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
