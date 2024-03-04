using DataAccess.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Models.Errors;

namespace DataAccess.Repositories;

public class SignRepository(UserManager<UserEntity> userManager) : ISignRepository
{
    public async Task<Result> SignUpUserAsync(UserEntity userEntity, string password)
    {
        var user = await userManager.FindByNameAsync(userEntity.UserName);
        if (user != null) return UserError.UserAlreadyExist;

        string passwordHash = userManager.PasswordHasher.HashPassword(userEntity, password);
        userEntity.PasswordHash = passwordHash;

        var result = await userManager.CreateAsync(userEntity);
        if(result.Succeeded) return Result.Success();

        var identityError = result.Errors.FirstOrDefault();
        if (identityError != null) return Result.Failure(new Error(identityError.Code, identityError.Description));

        return Error.None;
    }

    public async Task<Result> SignInUserAsync(UserEntity userEntity, string password)
    {
        if (userEntity.UserName == null) return ModelError.EmptyUserName;
        var user = await userManager.FindByNameAsync(userEntity.UserName);

        if(user == null) return UserError.UserNotFound;
        var isPasswordCorrect = await userManager.CheckPasswordAsync(user, password);

        return !isPasswordCorrect ? UserError.WrongPassword : Result.Success();
    }
    
}