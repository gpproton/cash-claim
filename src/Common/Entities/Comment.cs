using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class Comment : BaseEntity {
    public Claim Claim { get; set; }
    public User User { get; set; }
    public string Message { get; set; } = string.Empty;
}
