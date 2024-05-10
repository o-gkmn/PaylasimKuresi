using System.Security.Claims;
using Models.DTOs.UserDTOs;

namespace Business.PaylasimKuresi.Interfaces.UserServices;

public interface IUserService
{
    Task<GetUserDto?> RetrieveUserByPrincipalAsync(ClaimsPrincipal user);
}
