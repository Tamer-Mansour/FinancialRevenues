using AutoMapper;
using FinancialRevenues.Base;
using FinancialRevenues.Extentions;
using FinancialRevenues.Revenues.Dtos;
using FinancialRevenues.Revenues.Entities;
using FinancialRevenues.Revenues.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FinancialRevenues.Revenues.Services;

public class RevenueService : IRevenueService
{
    private readonly IMapper _mapper;
    private readonly IRevenueRepository _revenueRepository;
    public RevenueService(IMapper mapper, IRevenueRepository revenueRepository)
    {
        if (mapper == null) throw new ArgumentNullException(nameof(mapper));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));;
        _revenueRepository = revenueRepository;
    }

    public async Task AddAsync(CreateOrEditRevenueDto input)
    {
        var revenue = _mapper.Map<Revenue>(input);
        await _revenueRepository.InsertAsync(revenue);
    }

    public async Task ModifyAsync(CreateOrEditRevenueDto input)
    {
        var revenue = _mapper.Map<Revenue>(input);
        await _revenueRepository.UpdateAsync(revenue);
    }

    public async Task<GetRevenueForViewDto> GetRevenueForViewAsync(EntityDto<Guid> input)
    {
        var revenue = await _revenueRepository.GetAllAsync()
            .Include(e => e.GovernorateFk)
            .Include(e => e.RevenueTypeFk)
            .Include(e => e.CreatorUserFk)
            .Where(e => e.Id == input.Id && (bool)(!e.IsDeleted)!)
            .FirstOrDefaultAsync();
        return _mapper.Map<GetRevenueForViewDto>(revenue);
    }

    public async Task<GetRevenueForEditOutput> GetRevenueForEditAsync(EntityDto<Guid> input)
    {
        var revenue = await _revenueRepository.GetAllAsync()
            .Include(e => e.GovernorateFk)
            .Include(e => e.RevenueTypeFk)
            .Include(e => e.CreatorUserFk)
            .Where(e => e.Id == input.Id && (bool)(!e.IsDeleted)!)
            .FirstOrDefaultAsync();
        return _mapper.Map<GetRevenueForEditOutput>(revenue);    }

    public async Task<IList<GetRevenueForViewDto>> GetAllAsync(GetAllRevenuesInput input)
    {
        var filteredRevenues = await _revenueRepository.GetAllAsync()
            .Include(e => e.RevenueTypeFk)
            .Include(e => e.GovernorateFk)
            .Include(e => e.CreatorUserFk)
            .WhereIf(input.GovernorateId != null, e => e.GovernorateId == input.GovernorateId)
            .WhereIf(input.RevenueTypeId != null, e => e.RevenueTypeId == input.RevenueTypeId)
            .WhereIf(string.IsNullOrEmpty(input.PayerSSN),
                e => input.PayerSSN != null && e.PayerSSN.Contains(input.PayerSSN))
            .WhereIf(string.IsNullOrEmpty(input.Ref), e => input.Ref != null && e.Ref.Contains(input.Ref))
            .Where(e => (bool)(!e.IsDeleted)!)
            .ToListAsync();
        return _mapper.Map<IList<GetRevenueForViewDto>>(filteredRevenues);
    }

    public async Task<IList<GetRevenueForViewDto>> GetAllPagedAsync(GetAllRevenuesInput input)
    {
        var filteredRevenues = await _revenueRepository.GetAllAsync()
            .Include(e => e.RevenueTypeFk)
            .Include(e => e.GovernorateFk)
            .Include(e => e.CreatorUserFk)
            .WhereIf(input.GovernorateId != null, e => e.GovernorateId == input.GovernorateId)
            .WhereIf(input.RevenueTypeId != null, e => e.RevenueTypeId == input.RevenueTypeId)
            .WhereIf(string.IsNullOrEmpty(input.PayerSSN),
                e => input.PayerSSN != null && e.PayerSSN.Contains(input.PayerSSN))
            .WhereIf(string.IsNullOrEmpty(input.Ref), e => input.Ref != null && e.Ref.Contains(input.Ref))
            .PageBy((int)input.SkipCount!, (int)input.MaxResultCount!)
            .Where(e => (bool)(!e.IsDeleted)!)
            .ToListAsync();
        return _mapper.Map<IList<GetRevenueForViewDto>>(filteredRevenues);
    }

    public async Task<IList<GetRevenueForEditOutput>> GetAllDeletedAsync()
    {
        var deletedRevenues = await _revenueRepository.GetAllDeleted();
        return _mapper.Map<IList<GetRevenueForEditOutput>>(deletedRevenues);
    }

    public async Task SoftDeleteAsync(EntityDto<Guid> input)
    {
        await _revenueRepository.SoftDeleteAsync(input.Id);
    }
    public async Task HardDeleteAsync(EntityDto<Guid> input)
    {
        await _revenueRepository.HardDeleteAsync(input.Id);
    }
}