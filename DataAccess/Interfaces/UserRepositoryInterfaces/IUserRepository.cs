using Models.Entities;

namespace DataAccess.Interfaces.UserRepositoryInterfaces
{
    public interface IUserRepository
    {
        Task<string> CreateResetPasswordTokenAsync(string email);
        Task<UserEntity> FindByEmailAsync(string email);
        Task<string> FindIdByEmailAsync(string email);
        Task<UserEntity> FindUserByUserNameAsync(string userName);
        Task<bool> ResetPasswordAsync(string id, string token, string newPassword);
    }
}