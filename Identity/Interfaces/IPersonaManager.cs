using Identity.Models;

namespace Identity.Interfaces;

public interface IPersonaManager
{
    Task<UserEntity> FindUserByUserName(string userName);
}