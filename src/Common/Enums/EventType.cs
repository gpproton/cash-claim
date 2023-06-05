using System.ComponentModel;

namespace XClaim.Common.Enums;

public enum EventType {
    Claim,
    Payment,
    Review,
    Comment,
    Reminder,
    Announcement,
    [Description("Weekly Status")]
    WeeklyStatus
}