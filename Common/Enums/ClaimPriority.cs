using System.ComponentModel;

namespace CashClaim.Common.Enums;

public enum ClaimPriority {
    Normal,
    Urgent,
    [Description("Show Stopper")]
    ShowStopper
}