using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.VoicePostDTOs;

namespace Business.PaylasimKuresi.Interfaces.VoicePostServices;

public interface IVoicePostService : ICommonOperation<CreateVoicePostDto, UpdateVoicePostDto, GetVoicePostDto>
{

}
