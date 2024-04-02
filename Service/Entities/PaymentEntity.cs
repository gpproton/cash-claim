using System.ComponentModel.DataAnnotations;
using CashClaim.Common.Base;

namespace CashClaim.Service.Entities;

public sealed class PaymentEntity : TimedEntity {
    [MaxLength(256)]
    public string? Description { get; set; }
    [MaxLength(1024)]
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public UserEntity? CreatedBy { get; set; }
    public Guid? CreatedById { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public bool Confirmed => ConfirmedAt != null;
    public int Count { get; set; }
    public ICollection<ClaimEntity> Claims { get; set; } = default!;
    public ICollection<FileEntity> Files { get; set; } = default!;
    public ICollection<CommentEntity> Comments { get; set; } = default!;
}