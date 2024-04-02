using AutoFilterer.Attributes;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.DomainModule;

public class DomainFilter : GenericFilter {
    [CompareTo(nameof(DomainEntity.Address), nameof(DomainEntity.Description))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}