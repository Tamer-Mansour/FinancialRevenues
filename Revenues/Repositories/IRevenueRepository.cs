using FinancialRevenues.Revenues.Dtos;
using FinancialRevenues.Revenues.Entities;

namespace FinancialRevenues.Revenues.Repositories;

public interface IRevenueRepository : IBaseRepository<Revenue, Guid>
{
    public Task InsertRangeAsync(IEnumerable<Revenue> revenues);
    public Task<IList<Revenue>> GetAllDeleted();
}