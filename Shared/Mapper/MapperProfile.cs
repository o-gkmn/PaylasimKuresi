﻿using AutoMapper;
using Models.DTOs.UserDTOs;
using Models.Entities;

namespace Shared.Mapper;

public class MapperProfile : Profile
{
    public MapperProfile()
    {
        CreateMap<SignUpUserDto, UserEntity>();
        CreateMap<SignInUserDto, UserEntity>();
    }
}