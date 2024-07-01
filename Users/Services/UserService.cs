using AutoMapper;
using FinancialRevenues.Base;
using FinancialRevenues.Users.Dtos;
using FinancialRevenues.Users.Entities;
using FinancialRevenues.Users.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialRevenues.Users.Services;

public class UserService(IMapper mapper, IUserRepository userRepository): IUserService
{
    public async Task<GetUserForViewDto> GetAsync(long Id)
    {
        var user = await userRepository.GetAllAsync()
            .Include(e => e!.GovernorateFk)
            .Where(e => e.Id == Id)
            .FirstOrDefaultAsync();
        return mapper.Map<GetUserForViewDto>(user);
    }
    public async Task AddAsync(CreateOrEditUserDto input)
    {
        var user = mapper.Map<User>(input);
        await userRepository.InsertAsync(user, input.RolesName);
    }
    public async Task ChangePasswordAsync(ChangePasswordInput input)
    {
        await userRepository.ChangePassword(input);
    }
}