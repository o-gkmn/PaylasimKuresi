using DataAccess.DbContext;
using DataAccess.Interfaces.CommentLikeRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.CommentLikeRepositories;

public class CommentLikeRepository : CommonOperations<CommentLike>, ICommentLikeRepository
{
    public CommentLikeRepository(EFContext context) : base(context)
    {
    }
}
