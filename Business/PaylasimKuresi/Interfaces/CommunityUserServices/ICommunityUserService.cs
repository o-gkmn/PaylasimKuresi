using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.CommunityUserDTOs;

namespace Business.PaylasimKuresi.Interfaces.CommunityUserServices;

public interface ICommunityUserService : ICommonOperation<CreateCommunityUserDto, UpdateCommunityUserDto, GetCommunityUserDto>
{

}
