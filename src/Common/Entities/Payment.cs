using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class Payment : BaseEntity {
    public Decimal Amount { get; set; } = 0;
    public Bank Bank { get; set; }
    public ICollection<Claim> Claims { get; set; }
    public User User { get; set; }
    public DateTime CompletedAt { get; set; }
}
