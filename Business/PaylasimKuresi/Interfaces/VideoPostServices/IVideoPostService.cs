using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.VideoPostDTOs;

namespace Business.PaylasimKuresi.Interfaces.VideoPostServices;

public interface IVideoPostService : ICommonOperation<CreateVideoPostDto, UpdateVideoPostDto, GetVideoPostDto>
{

}
