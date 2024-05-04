using Business.PaylasimKuresi.Interfaces.CommonOperations;
using Models.DTOs.DmDTOs;

namespace Business.PaylasimKuresi.Interfaces.DmServices;

public interface IDmService : ICommonOperation<CreateDmDto, UpdateDmDto, GetDmDto>
{

}
