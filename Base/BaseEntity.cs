namespace FinancialRevenues;

public abstract class BaseEntity <TPrimaryKey>
{
    public TPrimaryKey Id { get; set; }
    public bool? IsDeleted { get; set; }
}