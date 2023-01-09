using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class PaymentEntity : BaseEntity {
    [MaxLength(256)]
    public string? Description { get; set; }
    [MaxLength(1024)]
    public string? Notes { get; set; }
    public decimal Amount { get; set; }
    [Required]
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public DateTime? CompletedAt { get; set; }
    public UserEntity? CompletedBy { get; set; }
    public bool Completed {
        get {
            return CompletedAt != null;
        }
    }
    public Guid? CompletedById { get; set; }
    public ICollection<ClaimEntity>? Claims { get; set; }
}