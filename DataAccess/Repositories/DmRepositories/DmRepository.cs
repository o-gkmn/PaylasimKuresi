using DataAccess.DbContext;
using DataAccess.Interfaces.DmRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.DmRepositories;

public class DmRepository : CommonOperations<Dm>, IDmRepository
{
    public DmRepository(EFContext context) : base(context)
    {
    }
}
