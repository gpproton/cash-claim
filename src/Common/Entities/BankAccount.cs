using XClaim.Common.Base;

namespace XClaim.Common.Entities;

internal class BankAccount : BaseEntity {
    public string Name { get; set; } = string.Empty;
    public Bank Bank { get; set; }
    public string Number { get; set; }
}
