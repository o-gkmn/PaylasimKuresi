using AutoMapper;
using Identity.Models;
using Models.DTOs.UserDTOs;

namespace Infrastructure.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignUpUserDto, UserEntity>();
        CreateMap<SignInUserDto, UserEntity>();
    }
}
//hoist the colour are wee