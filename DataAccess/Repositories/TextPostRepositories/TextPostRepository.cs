using DataAccess.DbContext;
using DataAccess.Interfaces.TextPostRepositories;
using DataAccess.Repositories.CommonOperations;
using Models.Entities;

namespace DataAccess.Repositories.TextPostRepositories;

public class TextPostRepository : CommonOperations<TextPost>, ITextPostRepository
{
    public TextPostRepository(EFContext context) : base(context)
    {
    }
}
