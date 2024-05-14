using System.Linq.Expressions;
using System.Security.Claims;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.PaylasimKuresi.Interfaces.UserServices;
using DataAccess.Interfaces.UserRepositories;
using Models.DTOs.UserDTOs;
using Models.Entities;

namespace Business.PaylasimKuresi.Services.UserServices;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserDto?> GetAsync(Expression<Func<GetUserDto, bool>> filter)
    {
        var convertedFilter = _mapper.MapExpression<Expression<Func<User, bool>>>(filter);
        var result = await _userRepository.GetAsync(convertedFilter);

        var mappedUser = _mapper.Map<GetUserDto>(result);
        return mappedUser;
    }

    public async Task<GetUserDto?> RetrieveUserByPrincipalAsync(ClaimsPrincipal user)
    {
        if (user.Identity is null)
            return null;


        if (user.Identity.Name is null)
            return null;

        var result = await _userRepository.FindUserByUserNameAsync(user.Identity.Name);

        var userDto = _mapper.Map<GetUserDto>(result);
        return userDto;
    }
}
