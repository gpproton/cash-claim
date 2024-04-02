using System.ComponentModel;

namespace CashClaim.Common.Enums;

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