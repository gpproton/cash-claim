using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Service.Entities;

public class NotificationEntity : TimedEntity {
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public bool Disabled { get; set; }
    public ICollection<NotificationChannels> Channels { get; set; } = default!;
    public ICollection<EventType> Types { get; set; } = default!;
}