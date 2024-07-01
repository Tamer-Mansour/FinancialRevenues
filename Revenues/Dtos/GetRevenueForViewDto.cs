namespace FinancialRevenues.Revenues.Dtos;

public class GetRevenueForViewDto
{
    public decimal ValueInJOD { get; set; }
    public string PayerSSN { get; set; }
    public string Ref {  get; set; }
    public string GovernorateFkName { get; set; }
    public string RevenueTypeFkName { get; set; }
    public string Description {get; set;}
}