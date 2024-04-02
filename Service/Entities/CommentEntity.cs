using System.ComponentModel.DataAnnotations;
using CashClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public sealed class CommentEntity : TimedEntity {
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public ClaimEntity? Claim { get; set; }
    public Guid? ClaimId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public Guid? PaymentId { get; set; }
    [MaxLength(1024)]
    public string? Content { get; set; }
}