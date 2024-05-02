using DataAccess.DbContext;
using DataAccess.Interfaces.PostLikeRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.PostLikeRepositories;

public class PostLikeRepository : CommonOperations<PostLike>, IPostLikeRepository
{
    public PostLikeRepository(EFContext context) : base(context)
    {
    }
}
