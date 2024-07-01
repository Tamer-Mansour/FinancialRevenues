using FinancialRevenues.Base;
using FinancialRevenues.Users.Dtos;
using FinancialRevenues.Users.Entities;

namespace FinancialRevenues.Users.Services;

public interface IUserService
{
    public Task<GetUserForViewDto> GetAsync(long Id);
    public Task AddAsync(CreateOrEditUserDto input);
    public Task ChangePasswordAsync(ChangePasswordInput input);
}