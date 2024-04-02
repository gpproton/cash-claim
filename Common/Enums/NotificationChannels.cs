using System.ComponentModel;

namespace CashClaim.Common.Enums {
    public enum NotificationChannels {
        [Description("Email Notifications")]
        Email,
        [Description("Push Notifications")]
        Push,
        [Description("SMS Notifications")]
        Sms,
        [Description("Teams Notifications")]
        Teams
    }
}