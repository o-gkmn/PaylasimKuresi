using AutoMapper;
using Business.Authentication.Interfaces.SignServiceInterfaces;
using Business.Authentication.Interfaces.TokenManagerInterfaces;
using DataAccess.Interfaces.SignRepositories;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.TokenDTOs;
using Models.DTOs.UserDTOs;
using Models.Entities;
using Models.Errors;

namespace Business.Authentication.Concrete.SignService
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
            var userEntity = _mapper.Map<User>(user);

            if (userEntity == null) throw ModelError.ModelNull;
            if (user.Password.IsNullOrEmpty()) throw ModelError.EmptyPassword;

            var result = await _signRepository.SignInUserAsync(userEntity, user.Password);
            var token = _tokenManager.GenerateRefreshToken(result);

            return token;
        }

        public Task SignOutAsync(SignInUserDto user)
        {
            throw new NotImplementedException();
        }

        public async Task<TokenDto> SignUpAsync(CreateUserDto signUpUserDto)
        {
            var userEntity = _mapper.Map<User>(signUpUserDto);

            if (userEntity is null) throw ModelError.ModelNull;
            var result = await _signRepository.SignUpUserAsync(userEntity, signUpUserDto.Password);

            var token = _tokenManager.GenerateRefreshToken(userEntity);

            return token;
        }
    }
}
