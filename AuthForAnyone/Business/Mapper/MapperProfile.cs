using AuthenticationServiceApi.Models.Dtos.UserDtos;
using AuthenticationServiceApi.Models.Entities;
using AutoMapper;

namespace AuthenticationServiceApi.Business.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<SignUpUserDto, UserEntity>();
        }
    }
}
