using Identity.Interfaces;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Models.Errors;

namespace Identity.Services;

public class PersonaManager(UserManager<UserEntity> userManager) : IPersonaManager
{
    public async Task<UserEntity> FindUserByUserNameAsync(string userName)
    {
        var user = await userManager.FindByNameAsync(userName);
        return user ?? throw UserError.UserNotFound;
    }
}