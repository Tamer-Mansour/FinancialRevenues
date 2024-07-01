using FinancialRevenues.Base;
using FinancialRevenues.Lookups;

namespace FinancialRevenues.Revenues.Entities;

public class Revenue: FullAuditedEntity<Guid>
{
    public decimal ValueInJOD { get; set; }
    public string PayerSSN { get; set; }
    public string Ref {  get; set; }
    public int GovernorateId { get; set; }
    public Governorate GovernorateFk { get; set; }
    public int RevenueTypeId { get; set; }
    public RevenueType RevenueTypeFk { get; set; }
    public string Description {get; set;}
}