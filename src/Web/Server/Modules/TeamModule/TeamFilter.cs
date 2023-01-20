using AutoFilterer.Attributes;
using AutoFilterer.Enums;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.TeamModule;

public sealed class TeamFilter : GenericFilter {
    [CompareTo(nameof(TeamEntity.Name), nameof(TeamEntity.Description))]
    [ToLowerContainsComparison]
    public string? Search { get; set; }
}