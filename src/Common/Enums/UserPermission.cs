using System.ComponentModel;

namespace XClaim.Common.Enums;

public enum UserPermission {
    System,
    Administrator,
    [Description("Finance Manager")]
    Finance,
    Lead,
    Cashier,
    [Description("Department Head")]
    Standard
}