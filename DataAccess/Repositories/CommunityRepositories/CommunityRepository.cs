using DataAccess.DbContext;
using DataAccess.Interfaces.CommonOperations;
using DataAccess.Interfaces.CommunityRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.CommunityRepositories;

public class CommunityRepository : CommonOperations<Community>, ICommunityRepository
{
    public CommunityRepository(EFContext context) : base(context)
    {
    }
}
