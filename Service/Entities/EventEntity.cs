using System.ComponentModel.DataAnnotations;
using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Service.Entities;

public sealed class EventEntity : BaseEntity {
    public DateTime CreatedAt { get; set; }
    public EventType Type { get; set; } = EventType.Claim;
    public ClaimEntity? Claim { get; set; }
    public Guid? ClaimId { get; set; }
    public PaymentEntity? Payment { get; set; }
    public Guid? PaymentId { get; set; }
    [MaxLength(512)]
    public string Description { get; set; } = string.Empty;
}