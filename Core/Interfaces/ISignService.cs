using Models.DTOs.UserDTOs;
using Models.Errors;

namespace Core.Interfaces
{
    public interface ISignService
    {
        public Task<Result> SignInAsync(SignInUserDto user);
        public Task SignOutAsync(SignInUserDto user);
        public Task<Result> SignUpAsync(SignUpUserDto signUpUserDto);
    }
}
