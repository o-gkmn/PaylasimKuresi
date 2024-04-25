using System.Linq.Expressions;
using DataAccess.DbContext;
using DataAccess.Interfaces.UserRepositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Entities;
using Models.Errors;

namespace DataAccess.Repositories.UserRepositories;

public class UserRepository : IUserRepository
{
    private readonly UserManager<User> _userManager;
    private readonly EFContext _context;

    public UserRepository(UserManager<User> userManager, EFContext context)
    {
        _userManager = userManager;
        _context = context;
    }

    public async Task<User> FindUserByUserNameAsync(string userName)
    {
        var user = await _userManager.FindByNameAsync(userName);
        return user ?? throw UserError.UserNotFound;
    }

    public async Task<User> FindByEmailAsync(string email)
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

    public async Task<User?> GetAsync(Expression<Func<User, bool>> filter)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(filter);
        return entity ?? null;
    }

    public async Task<List<User>> GetListAsync(Expression<Func<User, bool>>? filter = null)
    {
        if (filter == null)
            return await _context.Users.ToListAsync();
        else
            return await _context.Users.Where(filter).ToListAsync();
    }

    public Task<User> CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> UpdateAsync(User entity)
    {
        var result = await _userManager.UpdateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteAsync(User entity)
    {
        var result = await _userManager.DeleteAsync(entity);
        return result.Succeeded;
    }
}
