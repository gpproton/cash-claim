using System.ComponentModel;

namespace XClaim.Common.Enums;

public enum UserPermission {
    System,
    Administrator,
    [Description("Finance Manager")]
    Finance,
    [Description("Department Head")]
    Lead,
    Cashier,
    Standard,
    Anonymous
}