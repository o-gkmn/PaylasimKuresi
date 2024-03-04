using Identity.Models;
using Models.DTOs.UserDTOs;
using Models.Errors;

namespace DataAccess.Interfaces;

public interface ISignRepository
{
    public Task<Result> SignUpUserAsync(UserEntity userEntity, string password);
    public Task<Result> SignInUserAsync(UserEntity userEntity, string password);
}