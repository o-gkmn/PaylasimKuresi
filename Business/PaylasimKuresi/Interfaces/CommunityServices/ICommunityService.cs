using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.CommunityDTOs;

namespace Business.PaylasimKuresi.Interfaces.CommunityServices;

public interface ICommunityService : ICommonOperation<CreateCommunityDto, UpdateCommunityDto, GetCommunityDto>
{

}
