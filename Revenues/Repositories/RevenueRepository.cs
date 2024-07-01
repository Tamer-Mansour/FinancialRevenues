using FinancialRevenues.DbContexts;
using FinancialRevenues.Extentions;
using FinancialRevenues.Revenues.Dtos;
using FinancialRevenues.Revenues.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinancialRevenues.Revenues.Repositories;

public class RevenueRepository(FinancialRevenuesDbContext context) : IRevenueRepository
{
    public IQueryable<Revenue> GetAllAsync()
    {
        return context.Revenues.Where(e=>(bool)(!e.IsDeleted)!).AsQueryable();
    }

    public IQueryable<Revenue> GetAllIgnoreFilter()
    {
        return context.Revenues.AsQueryable();
    }

    public async Task<Revenue> GetAsync(Guid Id)
    {
        return await context.Revenues.Where(e => e.Id == Id && (bool)(!e.IsDeleted)!)
                   .FirstOrDefaultAsync() 
               ?? throw new Exception();
    }

    public async Task InsertAsync(Revenue revenue)
    {
        await context.Revenues.AddAsync(revenue);
        await context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Revenue revenue)
    {
        context.Revenues.Update(revenue);
        await context.SaveChangesAsync();
    }

    public async Task SoftDeleteAsync(Guid Id)
    {
        var revenue = await GetAsync(Id);
        revenue.IsDeleted = true;
        await context.SaveChangesAsync();
    }

    public async Task HardDeleteAsync(Guid Id)
    {
        var revenue = await GetAsync(Id);
        context.Revenues.Remove(revenue);
        await context.SaveChangesAsync();
    }

    public async Task InsertRangeAsync(IEnumerable<Revenue> revenues)
    {
        await context.Revenues.AddRangeAsync(revenues);
        await context.SaveChangesAsync();
    }

    public async Task<IList<Revenue>> GetAllDeleted()
    {
        var deletedRevenues = await context.Revenues.Where(e => (bool)e.IsDeleted!).ToListAsync();
        return deletedRevenues;
    }
}