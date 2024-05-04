using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.RoleDTOs;

namespace Business.PaylasimKuresi.Interfaces.RoleServices;

public interface IRoleService : ICommonOperation<CreateRoleDto, UpdateRoleDto, GetRoleDto>
{

}
