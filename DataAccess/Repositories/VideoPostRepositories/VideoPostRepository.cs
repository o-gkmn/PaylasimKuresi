using DataAccess.DbContext;
using DataAccess.Interfaces.VideoPostRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.VideoPostRepositories;

public class VideoPostRepository : CommonOperations<VideoPost>, IVideoPostRepository
{
    public VideoPostRepository(EFContext context) : base(context)
    {
    }
}
