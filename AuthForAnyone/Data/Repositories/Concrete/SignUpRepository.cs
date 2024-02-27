using AuthenticationServiceApi.Data.Repositories.Abstract;
using AuthenticationServiceApi.Models.Entities;
using AuthForAnyone.Models.Errors;
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

        public async Task<Result> RegisterUserAsync(UserEntity userEntity, string password)
        {
            string passwordHash = _userManager.PasswordHasher.HashPassword(userEntity, password);
            userEntity.PasswordHash = passwordHash;

            var result = await _userManager.CreateAsync(userEntity);

            if (!result.Succeeded)
            {
                List<Error> errors = new List<Error>();
                foreach (var error in result.Errors)
                {
                    errors.Add(new Error(error.Code, error.Description));
                }

                return Result.Failure(errors);
            }

            return Result.Success();
        }

        public async Task<bool> IsUserExistAsync(UserEntity userEntity)
        {
            UserEntity? result = await _userManager.FindByNameAsync(userEntity.UserName);

            if (result == null)
            {
                return false;
            }

            return true;
        }
    }
}
