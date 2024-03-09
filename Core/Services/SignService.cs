using AutoMapper;
using Core.Interfaces;
using DataAccess.Interfaces;
using Identity.Models;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace Core.Services
{
    public class SignService : ISignService
    {
        private readonly IMapper _mapper;
        private readonly ISignRepository _signRepository;
        private readonly TokenManager _tokenManager;

        public SignService(IMapper mapper, ISignRepository signRepository)
        {
            _mapper = mapper;
            _signRepository = signRepository;
        }

        public async Task<Token> SignInAsync(SignInUserDto user)
        {
            var userEntity = _mapper.Map<UserEntity>(user);

            if (userEntity == null) throw ModelError.ModelNull;
            if (user.Password.IsNullOrEmpty()) throw ModelError.EmptyPassword;

            var result = await _signRepository.SignInUserAsync(userEntity, user.Password);
            var token = _tokenManager.GenerateRefreshToken(userEntity);

            return token;
        }

        public Task SignOutAsync(SignInUserDto user)
        {
            throw new NotImplementedException();
        }
     


        public async Task<Token> SignUpAsync(SignUpUserDto signUpUserDto)
        {
            var userEntity = _mapper.Map<UserEntity>(signUpUserDto);

            if (userEntity is null) throw ModelError.ModelNull;
            var result = await _signRepository.SignUpUserAsync(userEntity, signUpUserDto.Password);

            var token = _tokenManager.GenerateRefreshToken(userEntity);

            return token;
        }
    }
}
