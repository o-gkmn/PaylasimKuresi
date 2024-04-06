using Models.Entities;

namespace DataAccess.Interfaces.SignRepositoryInterfaces;

public interface ISignRepository
{
    public Task<UserEntity> SignUpUserAsync(UserEntity userEntity, string password);
    public Task<UserEntity> SignInUserAsync(UserEntity userEntity, string password);
}