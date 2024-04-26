using System.Linq.Expressions;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace Business.PaylasimKuresi.Interfaces.UserServices;

public interface IUserService
{
    Task<string> CreateResetPasswordTokenAsync(string email);
    Task<User> FindByEmailAsync(string email);
    Task<string> FindIdByEmailAsync(string email);
    Task<User> FindUserByUserNameAsync(string userName);
    Task<bool> ResetPasswordAsync(string id, string token, string newPassword);
    Task<User?> GetAsync(Expression<Func<User, bool>> filter);
    Task<List<User>> GetListAsync(Expression<Func<User, bool>>? filter = null);
    Task<IdentityResult> UpdateAsync(User entity);
    Task<bool> DeleteAsync(User entity);
}
