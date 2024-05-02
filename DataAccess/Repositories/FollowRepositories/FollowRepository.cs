using DataAccess.DbContext;
using DataAccess.Interfaces.CommonOperations;
using DataAccess.Interfaces.FollowRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.FollowRepositories;

public class FollowRepository : CommonOperations<Follow>, IFollowRepository
{
    public FollowRepository(EFContext context) : base(context)
    {
    }
}
