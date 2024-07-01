namespace FinancialRevenues.Revenues.Dtos;

public class GetAllRevenuesInput
{
    public int? GovernorateId { get; set; }
    public int? RevenueTypeId { get; set; }
    public string? PayerSSN { get; set; }
    public string? Ref {  get; set; }
    public int? SkipCount { get; set; }
    public int? MaxResultCount { get; set; }
}