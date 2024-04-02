using CashClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

public class DomainEntity : TimedEntity {
    public string Address { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string Description { get; set; } = string.Empty;
}