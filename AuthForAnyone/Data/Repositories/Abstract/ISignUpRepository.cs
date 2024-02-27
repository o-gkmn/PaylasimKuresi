using AuthenticationServiceApi.Models.Entities;

namespace AuthenticationServiceApi.Data.Repositories.Abstract
{
    public interface ISignUpRepository
    {
        public Task RegisterUserAsync(UserEntity userEntity, string password);
    }
}
