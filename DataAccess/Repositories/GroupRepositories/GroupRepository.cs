using DataAccess.DbContext;
using DataAccess.Interfaces.CommonOperations;
using DataAccess.Interfaces.GroupRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.GroupRepositories;

public class GroupRepository : CommonOperations<Group>, IGroupRepository
{
    public GroupRepository(EFContext context) : base(context)
    {
    }
}
