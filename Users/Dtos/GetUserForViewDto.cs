using FinancialRevenues.Users.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Users.Dtos;

public class GetUserForViewDto
{
    public UserDto UserDto { get; set; }
    public int GovernorateId { get; set; }
    public string GovernorateFkName { get; set; }
    public IEnumerable<IdentityRole<int>> Roles { get; set; }
    public string FullName { get; set; }
}