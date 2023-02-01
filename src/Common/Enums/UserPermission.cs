using System.ComponentModel;

namespace XClaim.Common.Enums;

public enum UserPermission {
    System,
    Administrator,
    [Description("Finance Manager")]
    Finance,
    Cashier,
    [Description("Department Head")]
    Lead,
    Standard
}