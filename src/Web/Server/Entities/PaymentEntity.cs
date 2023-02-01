using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public sealed class PaymentEntity : BaseEntity {
    [MaxLength(256)]
    public string? Description { get; set; }
    [MaxLength(1024)]
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    [Required]
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public DateTime? ConfirmedAt { get; set; }
    public UserEntity? ConfirmedBy { get; set; }
    public Guid? ConfirmedById { get; set; }
    public bool Confirmed => ConfirmedAt != null;
    public int Count { get; set; }
    public ICollection<ClaimEntity> Claims { get; set; } = default!;
    public ICollection<FileEntity> Files { get; set; } = default!;
    public ICollection<CommentEntity> Comments { get; set; } = default!;
}