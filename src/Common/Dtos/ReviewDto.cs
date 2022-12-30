namespace XClaim.Common.Dtos;

public record ReviewDto(Guid id, string Name, string Owner, decimal Amount, DateTime Time, string Status = "Completed",
    string Icon = "");