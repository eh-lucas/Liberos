using AutoMapper;
using Liberos.Api.Models;

namespace Liberos.Api.DTOs.Mappings;
public class UserDtoMappingProfile : Profile
{
    public UserDtoMappingProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
    }
}
