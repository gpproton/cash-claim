using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.TeamModule;

public sealed class TeamFilter : GenericFilter {
    [CompareTo(nameof(TeamEntity.Name), nameof(TeamEntity.Description))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}