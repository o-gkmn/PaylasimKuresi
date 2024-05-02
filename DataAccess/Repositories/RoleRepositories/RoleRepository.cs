using DataAccess.DbContext;
using DataAccess.Interfaces.RoleRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.RoleRepositories;

public class RoleRepository : CommonOperations<Role>, IRoleRepository
{
    public RoleRepository(EFContext context) : base(context)
    {
    }
}
