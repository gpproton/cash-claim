using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class PaymentEntity : BaseEntity {
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    [Required]
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public DateTime? CompletedAt { get; set; }
    public UserEntity? CompletedBy { get; set; }
    public Guid? CompletedById { get; set; }
    public ICollection<ClaimEntity>? Claims { get; set; }
}