using FinancialRevenues.Base;
using FinancialRevenues.Revenues.Dtos;

namespace FinancialRevenues.Revenues.Services;

public interface IRevenueService
{
    public Task AddAsync(CreateOrEditRevenueDto input);
    public Task ModifyAsync(CreateOrEditRevenueDto input);
    public Task<GetRevenueForViewDto> GetRevenueForViewAsync(EntityDto<Guid> input);
    public Task<GetRevenueForEditOutput> GetRevenueForEditAsync(EntityDto<Guid> input);
    public Task<IList<GetRevenueForViewDto>> GetAllAsync(GetAllRevenuesInput input);
    public Task<IList<GetRevenueForViewDto>> GetAllPagedAsync(GetAllRevenuesInput input);
    public Task<IList<GetRevenueForEditOutput>> GetAllDeletedAsync();
    public Task SoftDeleteAsync(EntityDto<Guid> input);
    public Task HardDeleteAsync(EntityDto<Guid> input);
}