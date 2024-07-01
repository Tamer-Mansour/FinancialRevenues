using FinancialRevenues.Base;
using FinancialRevenues.Lookups;
using FinancialRevenues.Users.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Users.Entities;

public class User : IdentityUser<long>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string SocialSecurityNumber { get; set; }
    public UserGenderEnum Gender { get; set; }
    public int GovernorateId { get; set; }
    public Governorate GovernorateFk { get; set; }
    public IEnumerable<IdentityRole<int>> Roles { get; set; }
    public string FullName => FirstName + " " + LastName;
}