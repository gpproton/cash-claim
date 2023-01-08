using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class Profile : BaseResponse {
    public Profile(string email, string? firstName, string? lastName, UserPermission? permission, decimal? balance, Team? team) {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Permission = permission;
        Balance = balance;
        Team = team;
    }

    public string Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public UserPermission? Permission { get; set; }
    public decimal? Balance { get; set; }
    public Team? Team { get; set; }
}