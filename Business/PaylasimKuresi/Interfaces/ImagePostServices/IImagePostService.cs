using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.ImagePostDTOs;

namespace Business.PaylasimKuresi.Interfaces.ImagePostServices;

public interface IImagePostService : ICommonOperation<CreateImagePostDto, UpdateImagePostDto, GetImagePostDto>
{

}
