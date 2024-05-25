using Models.DTOs.UserDTOs;

namespace Business.Authentication.Interfaces.SignServiceInterfaces;

public interface ISignService
{
    Task<bool> SignInAsync(SignInUserDto signInDto);
    Task<bool> SignUpAsync(CreateUserDto createUserDto);
    Task SignOutAsync();
}
