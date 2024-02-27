using AuthenticationServiceApi.Models.Dtos.UserDtos;

namespace AuthenticationServiceApi.Business.Services.Abstract
{
    public interface ISignUpService
    {
        public Task RegisterUserAsync(SignUpUserDto signUpUserDto);
    }
}
