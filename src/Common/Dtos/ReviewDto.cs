namespace XClaim.Common.Dtos;

public record ReviewDto(string Name, string Owner, decimal Amount, DateTime Time, string Status = "Completed", string Icon = "");
