using DataAccess.DbContext;
using DataAccess.Interfaces.CommentRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.CommentRepositories
{
    public class CommentRepository : CommonOperations<Comment>, ICommentRepository
    {
        public CommentRepository(EFContext context) : base(context)
        {
        }
    }
}
