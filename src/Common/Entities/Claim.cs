using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Entities;

public class Claim : BaseEntity {
    public string Description { get; set; }
    public string? Notes { get; set; }
    public decimal Amount { get; set; } = 0;
    public Category Category { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public User Owner { get; set; }
    public User? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public User? ConfirmedBy { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public User? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public ICollection<Attachment>? Attachments { get; set; }
    public ICollection<Comment>? Comments { get; set; }
}
