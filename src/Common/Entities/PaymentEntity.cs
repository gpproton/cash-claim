using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class PaymentEntity : BaseEntity {
    public decimal Amount { get; set; } = 0;
    public BankAccountEntity? BankAccount { get; set; }
    public ICollection<ClaimEntity> Claims { get; set; }
    public UserEntity User { get; set; }
    public DateTime? CompletedAt { get; set; }
    public UserEntity? CompletedBy { get; set; }
}