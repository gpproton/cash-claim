using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record Profile {
    public Profile(string email, string? firstName, string? lastName, UserPermission? permission, decimal? balance, Team? team) {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Permission = permission;
        Balance = balance;
        Team = team;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public UserPermission? Permission { get; set; } = UserPermission.Standard;
    public decimal? Balance { get; set; }
    public Team? Team { get; set; }
}