using System.Linq.Expressions;
using System.Security.Claims;
using Models.DTOs.UserDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Interfaces.UserServices;

public interface IUserService
{
    Task<GetUserDto?> RetrieveUserByPrincipalAsync(ClaimsPrincipal user);
    Task<GetUserDto?> GetAsync(Expression<Func<GetUserDto, bool>> filter);
    Task<GetUserDto?> UpdateAsync(UpdateUserDto updateUserDto);
    Task<GetUserDto?> UpdateProfilePicture(UpdateProfilePictureUserDto updateProfilePictureUserDto);
}
