using FinancialRevenues.Revenues.Entities;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Revenues.Repositories;

public interface IBaseRepository<TEntity, in TPrimaryKey> where TEntity : BaseEntity<TPrimaryKey>
{
    public IQueryable<TEntity> GetAllAsync();
    public IQueryable<TEntity> GetAllIgnoreFilter(); 
    public Task<TEntity> GetAsync(TPrimaryKey Id);
    public Task InsertAsync(TEntity revenue);
    public Task UpdateAsync(TEntity revenue);
    public Task SoftDeleteAsync(TPrimaryKey Id);
    public Task HardDeleteAsync(TPrimaryKey Id);
}