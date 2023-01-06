using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record ProfileDto {
    public ProfileDto(string email, string? firstName, string? lastName, UserPermission? permission, decimal? balance, TeamDto? team) {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        Permission = permission;
        Balance = balance;
        Team = team;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Email { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public UserPermission? Permission { get; set; } = UserPermission.Standard;
    public decimal? Balance { get; set; }
    public TeamDto? Team { get; set; }
}