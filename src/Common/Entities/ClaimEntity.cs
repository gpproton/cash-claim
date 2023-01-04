using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Entities;

public class ClaimEntity : BaseEntity {
    public string Description { get; set; }
    public string? Notes { get; set; }
    public decimal Amount { get; set; } = 0;
    public CategoryEntity Category { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public UserEntity Owner { get; set; }
    public UserEntity? ReviewedBy { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public UserEntity? ConfirmedBy { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public UserEntity? ApprovedBy { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public ICollection<FileEntity>? Attachments { get; set; }
    public ICollection<CommentEntity>? Comments { get; set; }
}