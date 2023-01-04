using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Entities;

public class UserEntity : BaseEntity {
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserEntity? Manager { get; set; }
    public TeamEntity? Team { get; set; }
    public decimal Balance { get; set; } = 0;
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public bool Verified { get; set; }
    public string? Token { get; set; }
}