using DataAccess.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Models.Errors;

namespace DataAccess.Repositories;

public class SignUpRepository(UserManager<UserEntity> userManager) : ISignUpRepository
{
    public async Task<Result> RegisterUserAsync(UserEntity userEntity, string password)
    {
        string passwordHash = userManager.PasswordHasher.HashPassword(userEntity, password);
        userEntity.PasswordHash = passwordHash;

        var result = await userManager.CreateAsync(userEntity);

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
        UserEntity? result = await userManager.FindByNameAsync(userEntity.UserName);

        if (result == null)
        {
            return false;
        }

        return true;
    }
}