using AutoFilterer.Attributes;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.BankModule;

public sealed class BankFilter : GenericFilter {
    [CompareTo(nameof(BankEntity.Name), nameof(BankEntity.Description), nameof(BankEntity.SwiftCode))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}