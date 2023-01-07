using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record Profile : BaseResponse {
    public Profile(string email, string? firstName, string? lastName, UserPermission? permission, decimal? balance, Team? team) {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Permission = permission;
        Balance = balance;
        Team = team;
    }

    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public UserPermission? Permission { get; set; } = UserPermission.Standard;
    public decimal? Balance { get; set; }
    public Team? Team { get; set; }
}