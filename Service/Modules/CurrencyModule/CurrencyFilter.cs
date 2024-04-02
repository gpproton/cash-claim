using AutoFilterer.Attributes;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.CurrencyModule;

public class CurrencyFilter : GenericFilter {
    [CompareTo(nameof(CurrencyEntity.Name), nameof(CurrencyEntity.Description))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}