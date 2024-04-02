using AutoFilterer.Attributes;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.BankModule;

public sealed class BankFilter : GenericFilter {
    [CompareTo(nameof(BankEntity.Name), nameof(BankEntity.Description), nameof(BankEntity.SwiftCode))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}