using Models.Entities;

namespace DataAccess.Interfaces.SignRepositories;

public interface ISignRepository
{
    public Task<User> SignUpUserAsync(User userEntity, string password);
    public Task<User> SignInUserAsync(User userEntity, string password);
}
