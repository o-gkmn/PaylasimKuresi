using Identity.Models;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace DataAccess.Interfaces;

public interface ISignRepository
{
    public Task<UserEntity> SignUpUserAsync(UserEntity userEntity, string password);
    public Task<UserEntity> SignInUserAsync(UserEntity userEntity, string password);
}