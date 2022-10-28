using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class Claim : BaseEntity {
    public Decimal Amount { get; set; } = 0;
    public DateTime ReviewedAt { get; set; }
    public Category Category { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public User User { get; set; }
    public User? CheckedBy { get; set; }
    public User? ConfirmedBy { get; set; }
    public User? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public ICollection<Attachment> Attachments { get; set; }
    public ICollection<Comment> Comments { get; set; }
}
