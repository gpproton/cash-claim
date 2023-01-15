using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class DomainEntity : BaseEntity {
    public string Address { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string Description { get; set; } = string.Empty;
}