using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class NotificationResponse : BaseResponse {
    public UserResponse? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    public bool Disabled { get; set; }
    public ICollection<NotificationChannels> Channels { get; set; } = default!;
    public ICollection<EventType> Types { get; set; } = default!;
}