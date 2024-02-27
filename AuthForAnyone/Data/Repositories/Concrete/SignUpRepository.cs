using AuthenticationServiceApi.Data.Repositories.Abstract;
using AuthenticationServiceApi.Models.Entities;
using Microsoft.AspNetCore.Identity;

namespace AuthenticationServiceApi.Data.Repositories.Concrete
{
    public class SignUpRepository : ISignUpRepository
    {
        private readonly UserManager<UserEntity> _userManager;

        public SignUpRepository(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task RegisterUserAsync(UserEntity userEntity, string password)
        {
            string passwordHash = _userManager.PasswordHasher.HashPassword(userEntity, password);
            userEntity.PasswordHash = passwordHash;
            await _userManager.CreateAsync(userEntity);
        }
    }
}
