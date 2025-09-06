using AutoMapper;
using Liberos.Domain.Models;

namespace Liberos.Application.DTOs.Mappings;
public class UserLibraryDtoMappingProfile : Profile
{
    public UserLibraryDtoMappingProfile()
    {
        CreateMap<UserLibrary, UserLibraryDto>().ReverseMap();
    }
}