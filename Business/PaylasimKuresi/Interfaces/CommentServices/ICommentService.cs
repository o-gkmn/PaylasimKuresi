using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.CommentDTOs;

namespace Business.PaylasimKuresi.Interfaces.CommentServices;

public interface ICommentService : ICommonOperation<CreateCommentDto, UpdateCommentDto, GetCommentDto>
{

}
