using FinancialRevenues.Users.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Users.Dtos;

public class UserDto
{
    [PersonalData]
    public long Id { get; set; } = default!;
    [ProtectedPersonalData]
    public string? UserName { get; set; }
    [ProtectedPersonalData]
    public string? Email { get; set; }
    [PersonalData]
    public bool EmailConfirmed { get; set; }
    public string? PasswordHash { get; set; }
    public string? SecurityStamp { get; set; }
    public string? ConcurrencyStamp { get; set; } = Guid.NewGuid().ToString();
    [ProtectedPersonalData]
    public string? PhoneNumber { get; set; }
    [PersonalData]
    public bool PhoneNumberConfirmed { get; set; }
    [PersonalData]
    public bool TwoFactorEnabled { get; set; }
    public string SocialSecurityNumber { get; set; }
    public UserGenderEnum Gender { get; set; }
}