using Models.DTOs.UserDTOs;
using Models.Errors;

namespace Core.Interfaces;

public interface ISignUpService
{
    public Task<Result> RegisterUserAsync(SignUpUserDto signUpUserDto);
}