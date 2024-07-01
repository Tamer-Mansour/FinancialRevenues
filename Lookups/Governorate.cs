using FinancialRevenues.Base;

namespace FinancialRevenues.Lookups;

public class Governorate: BaseEntity<int>
{
    public string NameAr { get; set; }
    public string NameEn { get; set; }
    public virtual string Name => DisplayContent.LanguageSwitcher(NameAr,NameEn);
}