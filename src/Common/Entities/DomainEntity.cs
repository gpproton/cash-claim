using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class DomainEntity : BaseEntity {
    public string Address { get; set; } = default!;
}