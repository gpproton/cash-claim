using AutoFilterer.Attributes;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CurrencyModule;

public class CurrencyFilter : GenericFilter {
    [CompareTo(nameof(CurrencyEntity.Name), nameof(CurrencyEntity.Description))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}