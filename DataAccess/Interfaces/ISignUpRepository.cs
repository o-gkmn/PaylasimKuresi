using Identity.Models;
using Models.Errors;

namespace DataAccess.Interfaces;

public interface ISignUpRepository
{
    public Task<Result> RegisterUserAsync(UserEntity userEntity, string password);
    public Task<bool> IsUserExistAsync(UserEntity userEntity);
}