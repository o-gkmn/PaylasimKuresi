using AutoMapper;
using Business.Authentication.Interfaces.SignServiceInterfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Models.DTOs.UserDTOs;
using Models.Entities;
using Models.Errors;

namespace Business.Authentication.Concrete.SignService;

public class SignService : ISignService
{
    private readonly UserManager<User> _userManager;
    private readonly SignInManager<User> _signInManager;
    private readonly IMapper _mapper;

    public SignService(UserManager<User> userManager, SignInManager<User> signInManager, IMapper mapper)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _mapper = mapper;
    }

    public async Task<bool> SignInAsync(SignInUserDto signInDto)
    {
        var userEntity = _mapper.Map<User>(signInDto);

        if (userEntity == null) throw ModelError.ModelNull;
        if (userEntity.Email == null || userEntity.Email == "") throw ModelError.EmptyEmail;
        if (signInDto.Password.IsNullOrEmpty()) throw ModelError.EmptyPassword;

        var user = await _userManager.FindByEmailAsync(userEntity.Email);
        if (user == null) throw UserError.UserNotFound;

        var result = await _signInManager.PasswordSignInAsync(user, signInDto.Password, true, false);
        return result.Succeeded;
    }

    public async Task<bool> SignUpAsync(CreateUserDto createUserDto)
    {
        var userEntity = _mapper.Map<User>(createUserDto);

        if (userEntity is null) throw ModelError.ModelNull;
        var result = await _userManager.CreateAsync(userEntity, createUserDto.Password);

        return result.Succeeded;
    }
}
