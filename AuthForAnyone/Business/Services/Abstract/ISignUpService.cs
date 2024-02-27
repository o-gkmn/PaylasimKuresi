using AuthenticationServiceApi.Models.Dtos.UserDtos;
using AuthForAnyone.Models.Errors;

namespace AuthenticationServiceApi.Business.Services.Abstract
{
    public interface ISignUpService
    {
        public Task<Result> RegisterUserAsync(SignUpUserDto signUpUserDto);
    }
}
