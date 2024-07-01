using FinancialRevenues.Users.Entities;

namespace FinancialRevenues.Base;

public abstract class FullAuditedEntity<TPrimaryKey>: BaseEntity<TPrimaryKey>
{
    public long CreatorUserId { get; set; }
    public long DeleterUserId { get; set; }
    public User? CreatorUserFk { get; set; }
    public User? DeleterUserFk { get; set; }
    public DateTime CreationTime { get; set; }
    public DateTime? DeletionTime { get; set; }
    public DateTime? LastModificationTime { get; set; }
}