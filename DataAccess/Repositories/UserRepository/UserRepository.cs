using DataAccess.Interfaces.UserRepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Errors;

namespace DataAccess.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<UserEntity> _userManager;

        public UserRepository(UserManager<UserEntity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UserEntity> FindUserByUserNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);
            return user ?? throw UserError.UserNotFound;
        }

        public async Task<UserEntity> FindByEmailAsync(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return user ?? throw UserError.UserNotFound;
        }

        public async Task<string> CreateResetPasswordTokenAsync(string email)
        {
            var user = await FindByEmailAsync(email);
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            return token;
        }

        public async Task<bool> ResetPasswordAsync(string id, string token, string newPassword)
        {
            var user = await _userManager.FindByIdAsync(id);
            var newPasswordHash = _userManager.PasswordHasher.HashPassword(user, newPassword);

            var identityResult = await _userManager.ResetPasswordAsync(user, token, newPassword);

            var identityError = identityResult.Errors.FirstOrDefault();
            if (identityError != null) throw new Error(Convert.ToInt32(identityError.Code), "IdentityError", identityError.Description);

            return identityResult.Succeeded;
        }

        public async Task<string> FindIdByEmailAsync(string email)
        {
            var user = await FindByEmailAsync(email);
            return user.Id.ToString();
        }
    }
}
