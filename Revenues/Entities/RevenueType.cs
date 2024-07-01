using FinancialRevenues.Base;

namespace FinancialRevenues.Revenues.Entities;

public class RevenueType: BaseEntity<int>
{
    public string? NameEn { get; set; }
    public string? NameAr { get; set; }
    public virtual string Name => DisplayContent.LanguageSwitcher(NameAr,NameEn);
}