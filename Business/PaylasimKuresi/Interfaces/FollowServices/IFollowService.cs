using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.FollowDTOs;

namespace Business.PaylasimKuresi.Interfaces.FollowServices;

public interface IFollowService : ICommonOperation<CreateFollowDto, UpdateFollowDto, GetFollowDto>
{

}
