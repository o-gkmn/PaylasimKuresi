using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.PostLikeDTOs;

namespace Business.PaylasimKuresi.Interfaces.PostLikeServices;

public interface IPostLikeService : ICommonOperation<CreatePostLikeDto, UpdatePostLikeDto, GetPostLikeDto>
{

}
