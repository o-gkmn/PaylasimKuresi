using DataAccess.DbContext;
using DataAccess.Interfaces.PostRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.PostRepositories;

public class PostRepository : CommonOperations<Post>, IPostRepository
{
    public PostRepository(EFContext context) : base(context)
    {
    }
}
