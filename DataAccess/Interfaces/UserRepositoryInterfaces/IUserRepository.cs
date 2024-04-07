using Models.Entities;

namespace DataAccess.Interfaces.UserRepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<string> CreateResetPasswordTokenAsync(string email);
        Task<User> FindByEmailAsync(string email);
        Task<string> FindIdByEmailAsync(string email);
        Task<User> FindUserByUserNameAsync(string userName);
        Task<bool> ResetPasswordAsync(string id, string token, string newPassword);
    }
}
