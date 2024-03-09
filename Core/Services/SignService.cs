using AutoMapper;
using Core.Interfaces;
using DataAccess.Interfaces;
using Identity.Models;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace Core.Services
{
    public class SignService : ISignService
    {
        private readonly IMapper _mapper;
        private readonly ISignRepository _signRepository;

        public SignService(IMapper mapper, ISignRepository signRepository)
        {
            _mapper = mapper;
            _signRepository = signRepository;
        }

        public async Task<Result> SignInAsync(SignInUserDto user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            if (userEntity == null) return ModelError.ModelNull;
            if (user.Password.IsNullOrEmpty()) return ModelError.EmptyPassword;

            var result = await _signRepository.SignInUserAsync(userEntity, user.Password);

            return result;
        }

        public Task SignOutAsync(SignInUserDto user)
        {
            throw new NotImplementedException();
        }
     


        public async Task<Result> SignUpAsync(SignUpUserDto signUpUserDto)
        {
            var userEntity = _mapper.Map<UserEntity>(signUpUserDto);

            if (userEntity is null) return ModelError.ModelNull;
            var result = await _signRepository.SignUpUserAsync(userEntity, signUpUserDto.Password);

            return result;
        }
    }
}
