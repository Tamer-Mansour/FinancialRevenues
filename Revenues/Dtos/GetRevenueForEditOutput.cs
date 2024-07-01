namespace FinancialRevenues.Revenues.Dtos;

public class GetRevenueForEditOutput
{
    public CreateOrEditRevenueDto RevenueDto { get; set; }
    public string GovernorateFkName { get; set; }
    public string RevenueTypeFkName { get; set; }
    public string CreatorUserFkFullName { get; set; }
}