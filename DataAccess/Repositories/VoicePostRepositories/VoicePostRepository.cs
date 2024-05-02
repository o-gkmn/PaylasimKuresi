using DataAccess.DbContext;
using DataAccess.Interfaces.VoicePostRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.VoicePostRepositories;

public class VoicePostRepository : CommonOperations<VoicePost>, IVoicePostRepository
{
    public VoicePostRepository(EFContext context) : base(context)
    {
    }
}
