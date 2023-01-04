using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class CommentEntity : BaseEntity {
    public ClaimEntity? Claim { get; set; }
    public PaymentEntity? Payment { get; set; }
    public UserEntity User { get; set; }
    public string Message { get; set; } = string.Empty;
}