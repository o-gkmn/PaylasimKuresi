using Models.DTOs.TokenDTOs;
using Models.DTOs.UserDTOs;

namespace Core.Interfaces
{
    public interface ISignService
    {
        public Task<TokenDto> SignInAsync(SignInUserDto user);
        public Task SignOutAsync(SignInUserDto user);
        public Task<TokenDto> SignUpAsync(SignUpUserDto signUpUserDto);
    }
}
