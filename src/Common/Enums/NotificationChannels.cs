using System.ComponentModel;

namespace XClaim.Common.Enums {
    public enum NotificationChannels {
        [Description("Email NOtifications")]
        Email,
        [Description("Push NOtifications")]
        Push,
        [Description("SMS NOtifications")]
        Sms,
        [Description("MS Teams NOtifications")]
        Teams
    }
}