using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.PostDTOs;

namespace Business.PaylasimKuresi.Interfaces.PostServices;

public interface IPostService : ICommonOperation<CreatePostDto, UpdatePostDto, GetPostDto>
{

}
