using Models.DTOs;
using Models.DTOs.UserDTOs;

namespace Core.Interfaces
{
    public interface ISignService
    {
        public Task<Token> SignInAsync(SignInUserDto user);
        public Task SignOutAsync(SignInUserDto user);
        public Task<Token> SignUpAsync(SignUpUserDto signUpUserDto);
    }
}
