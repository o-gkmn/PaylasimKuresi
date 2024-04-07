using AutoMapper;
using Models.DTOs.UserDTOs;
using Models.Entities;

namespace Shared.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignUpUserDto, User>().ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth)));
        CreateMap<SignInUserDto, User>();
    }
}
