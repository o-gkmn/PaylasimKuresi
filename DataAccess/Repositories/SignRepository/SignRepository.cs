using DataAccess.Interfaces.SignRepositoryInterfaces;
using Microsoft.AspNetCore.Identity;
using Models.Entities;
using Models.Errors;

namespace DataAccess.Repositories.SignRepository;

public class SignRepository(UserManager<UserEntity> userManager) : ISignRepository
{
    public async Task<UserEntity> SignUpUserAsync(UserEntity userEntity, string password)
    {
        var user = await userManager.FindByNameAsync(userEntity.UserName);
        if (user != null) throw UserError.UserAlreadyExist;

        string passwordHash = userManager.PasswordHasher.HashPassword(userEntity, password);
        userEntity.PasswordHash = passwordHash;

        var result = await userManager.CreateAsync(userEntity);

        var identityError = result.Errors.FirstOrDefault();
        if (identityError != null) throw new Error(Convert.ToInt32(identityError.Code), "IdentityError", identityError.Description);

        var createdUser = await userManager.FindByNameAsync(userEntity.UserName);
        return createdUser ?? throw UserError.UserNotFound;
    }

    public async Task<UserEntity> SignInUserAsync(UserEntity userEntity, string password)
    {
        if (userEntity.UserName == null) throw ModelError.EmptyUserName;
        var user = await userManager.FindByNameAsync(userEntity.UserName);

        if (user == null) throw UserError.UserNotFound;
        var isPasswordCorrect = await userManager.CheckPasswordAsync(user, password);

        return !isPasswordCorrect ? throw UserError.WrongPassword : user;
    }

}