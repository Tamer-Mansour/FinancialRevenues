using System.Text.Json.Serialization;
using FinancialRevenues.Users.Dtos;

namespace FinancialRevenues.Base;

public class FullAuditedEntityDto<TPrimaryKey> : EntityDto<TPrimaryKey>
{
    [JsonIgnore]
    public long CreatorUserId { get; set; }
    [JsonIgnore]
    public long DeleterUserId { get; set; }
    [JsonIgnore]
    public CreateOrEditUserDto? CreatorUserFk { get; set; }
    [JsonIgnore]
    public CreateOrEditUserDto? DeleterUserFk { get; set; }
    [JsonIgnore]
    public DateTime CreationTime { get; set; }
    [JsonIgnore]
    public DateTime? DeletionTime { get; set; }
    [JsonIgnore]
    public DateTime? LastModificationTime { get; set; }
}