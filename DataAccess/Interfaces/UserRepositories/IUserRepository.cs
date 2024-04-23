using DataAccess.Interfaces.CommonOperations;
using Models.Entities;

namespace DataAccess.Interfaces.UserRepositories;

public interface IUserRepository : ICommonOperations<User>
{
    Task<string> CreateResetPasswordTokenAsync(string email);
    Task<User> FindByEmailAsync(string email);
    Task<string> FindIdByEmailAsync(string email);
    Task<User> FindUserByUserNameAsync(string userName);
    Task<bool> ResetPasswordAsync(string id, string token, string newPassword);
}
