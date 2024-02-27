using AuthenticationServiceApi.Business.Services.Abstract;
using AuthenticationServiceApi.Data.Repositories.Abstract;
using AuthenticationServiceApi.Models.Dtos.UserDtos;
using AuthenticationServiceApi.Models.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationServiceApi.Business.Services.Concrete
{
    public class SignUpService : ISignUpService
    {
        private readonly ISignUpRepository _signUpRepository;
        private readonly IMapper _mapper;

        public SignUpService(ISignUpRepository signUpRepository, IMapper mapper)
        {
            _signUpRepository = signUpRepository;
            _mapper = mapper;
        }

        public async Task RegisterUserAsync(SignUpUserDto signUpUserDto)
        {
            UserEntity mappedUser = _mapper.Map<UserEntity>(signUpUserDto);
            await _signUpRepository.RegisterUserAsync(mappedUser, signUpUserDto.Password);
        }
    }
}
