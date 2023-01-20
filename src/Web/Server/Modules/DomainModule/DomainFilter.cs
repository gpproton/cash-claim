using AutoFilterer.Attributes;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.DomainModule;

public class DomainFilter : GenericFilter {
    [CompareTo(nameof(DomainEntity.Address), nameof(DomainEntity.Description))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}