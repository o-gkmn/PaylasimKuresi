using DataAccess.DbContext;
using DataAccess.Interfaces.GroupUserRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.GroupUserRepositories;

public class GroupUserRepository : CommonOperations<GroupUser>, IGroupUserRepository
{
    public GroupUserRepository(EFContext context) : base(context)
    {
    }
}
