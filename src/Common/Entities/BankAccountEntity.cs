using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class BankAccountEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    public BankEntity Bank { get; set; }
    public string Number { get; set; }
    public string Description { get; set; }
}