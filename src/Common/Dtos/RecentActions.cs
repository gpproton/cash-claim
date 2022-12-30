namespace XClaim.Common.Dtos;

public record RecentActions(Guid id, string Name, string Category, decimal Amount, DateTime Time);