using AutoMapper;
using Liberos.Api.Models;

namespace Liberos.Api.DTOs.Mappings;
public class UserLibraryDtoMappingProfile : Profile
{
    public UserLibraryDtoMappingProfile()
    {
        CreateMap<UserLibrary, UserLibraryDto>().ReverseMap();
    }
}