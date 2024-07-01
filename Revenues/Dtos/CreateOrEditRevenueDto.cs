using FinancialRevenues.Base;

namespace FinancialRevenues.Revenues.Dtos;

public class CreateOrEditRevenueDto : EntityDto<Guid>
{
    public decimal ValueInJOD { get; set; }
    public string PayerSSN { get; set; }
    public string Ref {  get; set; }
    public string Description { get; set; }
    public int GovernorateId { get; set; }
    public int RevenueTypeId { get; set; }
    public int CreatorUserId { get; set; }
}