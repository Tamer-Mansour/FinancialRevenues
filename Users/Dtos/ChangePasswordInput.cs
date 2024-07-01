using FinancialRevenues.Users.Entities;

namespace FinancialRevenues.Users.Dtos;

public class ChangePasswordInput
{
    public string CurrentPassword { get; set; }
    public string NewPassword { get; set; }
    public User LoggedInUser { get; set; }
}
