using AutoMapper;
using Liberos.Domain.Models;

namespace Liberos.Application.DTOs.Mappings;
public class UserDtoMappingProfile : Profile
{
    public UserDtoMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
