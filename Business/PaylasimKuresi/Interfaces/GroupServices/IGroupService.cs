using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.GroupDTOs;

namespace Business.PaylasimKuresi.Interfaces.GroupServices;

public interface IGroupService : ICommonOperation<CreateGroupDto, UpdateGroupDto, GetGroupDto>
{

}
