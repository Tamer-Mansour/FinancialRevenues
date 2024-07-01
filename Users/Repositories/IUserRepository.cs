using FinancialRevenues.Revenues.Repositories;
using FinancialRevenues.Users.Dtos;
using FinancialRevenues.Users.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Users.Repositories;

public interface IUserRepository
{
    public IQueryable<User?> GetAllAsync();
    public Task<User?> GetAsync(long Id);
    public Task InsertAsync(User user, IEnumerable<string> rolesName);
    public Task ChangePassword(ChangePasswordInput input);
}