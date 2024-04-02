using System.ComponentModel.DataAnnotations;
using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace XClaim.Web.Server.Entities;

public sealed class ClaimEntity : TimedEntity {
    [Required]
    [MaxLength(256)]
    public string? Description { get; set; }
    [MaxLength(1024)]
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    public CurrencyEntity? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public Guid? PaymentId { get; set; }
    [Required]
    public CategoryEntity? Category { get; set; }
    public Guid? CategoryId { get; set; }
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public ClaimStatus Status { get; set; } = ClaimStatus.Pending;
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public DateTime? CancelledAt { get; set; }
    public UserEntity? ReviewedBy { get; set; }
    public Guid? ReviewedById { get; set; }
    public DateTime? ReviewedAt { get; set; }
    public UserEntity? ConfirmedBy { get; set; }
    public Guid? ConfirmedById { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public UserEntity? ApprovedBy { get; set; }
    public Guid? ApprovedById { get; set; }
    public DateTime? ApprovedAt { get; set; }
    public Guid? RejectedById { get; set; }
    public DateTime? RejectedAt { get; set; }
    public ICollection<FileEntity> Files { get; set; } = default!;
    public ICollection<CommentEntity> Comments { get; set; } = default!;
}