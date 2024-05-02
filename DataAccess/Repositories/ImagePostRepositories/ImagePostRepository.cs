using DataAccess.DbContext;
using DataAccess.Interfaces.ImagePostRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.ImagePostRepositories;

public class ImagePostRepository : CommonOperations<ImagePost>, IImagePostRepository
{
    public ImagePostRepository(EFContext context) : base(context)
    {
    }
}
