using DataAccess.DbContext;
using DataAccess.Interfaces.CommunityUserRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.CommunityUserRepositories;

public class CommunityUserRepository : CommonOperations<CommunityUser>, ICommunityUserRepository
{
    public CommunityUserRepository(EFContext context) : base(context)
    {
    }
}
