using AuthenticationServiceApi.Business.Services.Abstract;
using AuthenticationServiceApi.Data.Repositories.Abstract;
using AuthenticationServiceApi.Models.Dtos.UserDtos;
using AuthenticationServiceApi.Models.Entities;
using AuthForAnyone.Models.Errors;
using AutoMapper;

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

        public async Task<Result> RegisterUserAsync(SignUpUserDto signUpUserDto)
        {
            UserEntity mappedUser = _mapper.Map<UserEntity>(signUpUserDto);

            if (await _signUpRepository.IsUserExistAsync(mappedUser))
            {
                return UserError.UserAlreadyExist;
            }

            var result = await _signUpRepository.RegisterUserAsync(mappedUser, signUpUserDto.Password);

            return result;
        }
    }
}
