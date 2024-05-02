using System.Linq.Expressions;
using Business.PaylasimKuresi.Interfaces.UserServices;
using DataAccess.Interfaces.UserRepositories;
using Microsoft.AspNetCore.Identity;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.UserServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<string> CreateResetPasswordTokenAsync(string email)
    {
        var result = _userRepository.CreateResetPasswordTokenAsync(email);
        return result;
    }

    public async Task<bool> DeleteAsync(User entity)
    {
        var result = await _userRepository.DeleteAsync(entity);
        return result;
    }

    public async Task<User> FindByEmailAsync(string email)
    {
        var result = await _userRepository.FindByEmailAsync(email);
        return result;
    }

    public async Task<string> FindIdByEmailAsync(string email)
    {
        var result = await _userRepository.FindIdByEmailAsync(email);
        return result;
    }

    public async Task<User> FindUserByUserNameAsync(string userName)
    {
        var result = await _userRepository.FindUserByUserNameAsync(userName);
        return result;
    }

    public async Task<User?> GetAsync(Expression<Func<User, bool>> filter)
    {
        var result = await _userRepository.GetAsync(filter);
        return result;
    }

    public async Task<List<User>> GetListAsync(Expression<Func<User, bool>>? filter = null)
    {
        var result = await _userRepository.GetListAsync(filter);
        return result;
    }

    public async Task<bool> ResetPasswordAsync(string id, string token, string newPassword)
    {
        var result = await _userRepository.ResetPasswordAsync(id, token, newPassword);
        return result;
    }

    public async Task<IdentityResult> UpdateAsync(User entity)
    {
        var result = await _userRepository.UpdateAsync(entity);
        return result;
    }
}
