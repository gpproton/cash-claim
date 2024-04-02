using System.ComponentModel;

namespace XClaim.Common.Enums;

public enum ClaimPriority {
    Normal,
    Urgent,
    [Description("Show Stopper")]
    ShowStopper
}