using FinancialRevenues.DbContexts;
using FinancialRevenues.Users.Dtos;
using FinancialRevenues.Users.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinancialRevenues.Users.Repositories;

public class UserRepository(FinancialRevenuesDbContext context, UserManager<User> userManager): IUserRepository
{
    public IQueryable<User?> GetAllAsync()
    {
        return context.Users.AsQueryable();
    }

    public async Task<User?> GetAsync(long Id)
    {
        return await userManager.Users
            .Include(e => e.GovernorateFk)
            .Where(e => e.Id == Id)
            .FirstOrDefaultAsync();
    }

    public async Task InsertAsync(User user, IEnumerable<string> rolesName)
    {
        var user1 = await userManager.CreateAsync(user);
        await userManager.AddToRolesAsync(user, rolesName);
        await context.SaveChangesAsync();
    }

    public async Task ChangePassword(ChangePasswordInput input)
    {
        
        await userManager.ChangePasswordAsync(input.LoggedInUser, input.CurrentPassword, input.NewPassword);
        await context.SaveChangesAsync();
    }
}