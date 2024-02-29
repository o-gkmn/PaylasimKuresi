using AutoMapper;
using Core.Interfaces;
using DataAccess.Interfaces;
using Identity.Models;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace Core.Services;

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