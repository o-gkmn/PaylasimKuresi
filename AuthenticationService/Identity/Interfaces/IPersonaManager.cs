using Identity.Models;

namespace Identity.Interfaces;

public interface IPersonaManager
{
    Task<UserEntity> FindUserByUserNameAsync(string userName);
}