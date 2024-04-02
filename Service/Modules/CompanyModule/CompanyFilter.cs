using AutoFilterer.Attributes;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.CompanyModule;

public class CompanyFilter : GenericFilter {
    [CompareTo(nameof(CompanyEntity.ShortName), nameof(CompanyEntity.FullName))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}