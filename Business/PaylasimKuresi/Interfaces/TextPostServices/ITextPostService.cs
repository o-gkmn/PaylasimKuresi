using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.TextPostDTOs;

namespace Business.PaylasimKuresi.Interfaces.TextPostServices;

public interface ITextPostService : ICommonOperation<CreateTextPostDto, UpdateTextPostDto, GetTextPostDto>
{

}
