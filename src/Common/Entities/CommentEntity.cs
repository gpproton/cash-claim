using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class CommentEntity : BaseEntity {
    public ClaimEntity? Claim { get; set; }
    public Guid? ClaimId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public Guid? PaymentId { get; set; }
    [Required]
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    [Required]
    [MaxLength(1024)]
    public string? Content { get; set; }
}