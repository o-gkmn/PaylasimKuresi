using AutoMapper;
using Core.Interfaces;
using DataAccess.Interfaces;
using Identity.Models;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.TokenDTOs;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace Core.Services
{
    public class SignService : ISignService
    {
        private readonly IMapper _mapper;
        private readonly ISignRepository _signRepository;
        private readonly ITokenManager _tokenManager;

        public SignService(IMapper mapper, ISignRepository signRepository, ITokenManager tokenManager)
        {
            _mapper = mapper;
            _signRepository = signRepository;
            _tokenManager = tokenManager;
        }

        public async Task<TokenDto> SignInAsync(SignInUserDto user)
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

        public async Task<TokenDto> SignUpAsync(SignUpUserDto signUpUserDto)
        {
            var userEntity = _mapper.Map<UserEntity>(signUpUserDto);

            if (userEntity is null) throw ModelError.ModelNull;
            var result = await _signRepository.SignUpUserAsync(userEntity, signUpUserDto.Password);

            var token = _tokenManager.GenerateRefreshToken(userEntity);

            return token;
        }
    }
}
