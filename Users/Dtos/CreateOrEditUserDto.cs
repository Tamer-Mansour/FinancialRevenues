using System.ComponentModel.DataAnnotations;
using FinancialRevenues.Users.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinancialRevenues.Users.Dtos;

public class CreateOrEditUserDto
{
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string SocialSecurityNumber { get; set; }
    public int GovernorateId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public UserGenderEnum Gender { get; set; }
    public IEnumerable<string> RolesName { get; set; }
}