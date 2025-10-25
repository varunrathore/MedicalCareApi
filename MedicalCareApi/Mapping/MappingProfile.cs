using AutoMapper;
using MedicalCareApi.DTOs;
using MedicalCareApi.DTOs.User;
using MedicalCareApi.Models;

namespace MedicalCareApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<CreateUserRequestDto, User>();
        }
    }
}
