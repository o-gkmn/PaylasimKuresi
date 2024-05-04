using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.GroupUserDTOs;

namespace Business.PaylasimKuresi.Interfaces.GroupUserServices;

public interface IGroupUserService : ICommonOperation<CreateGroupUserDto, UpdateGroupUserDto, GetGroupUserDto>
{

}
