using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public sealed class BankEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
}