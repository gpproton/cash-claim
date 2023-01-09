using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class Profile : BaseResponse {
    public Profile(string email, string fullName, string phone, UserPermission permission = UserPermission.Standard, decimal balance = 0, Team team = default!) {
        Email = email;
        FullName = fullName;
        Phone = phone;
        Permission = permission;
        Balance = balance;
        Team = team;
    }

    public string Email { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public UserPermission Permission { get; set; }
    public decimal? Balance { get; set; }
    public Team? Team { get; set; }
}