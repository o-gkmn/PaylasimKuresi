using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.CommentLikeDTOs;

namespace Business.PaylasimKuresi.Interfaces.CommentLikeServices;

public interface ICommentLikeService : ICommonOperation<CreateCommentLikeDto, UpdateCommentLikeDto, GetCommentLikeDto>
{

}
