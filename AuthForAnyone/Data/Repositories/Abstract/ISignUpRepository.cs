using AuthenticationServiceApi.Models.Entities;
using AuthForAnyone.Models.Errors;

namespace AuthenticationServiceApi.Data.Repositories.Abstract
{
    public interface ISignUpRepository
    {
        public Task<Result> RegisterUserAsync(UserEntity userEntity, string password);
        public Task<bool> IsUserExistAsync(UserEntity userEntity);
    }
}
