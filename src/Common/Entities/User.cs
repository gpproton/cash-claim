using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class User : BaseEntity {
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public User? Manager { get; set; }
    public Team? Team { get; set; }
    public Decimal PendingBalance { get; set; } = 0;
    public UserPermission Permission { get; set; } = UserPermission.User;
    public bool Verfied { get; set; }
    public string? Token { get; set; }
}
