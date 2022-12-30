namespace XClaim.Common.Dtos;

public record ClaimDto(Guid id, string Name, string Category, decimal Amount, DateTime Time, string Notes = "",
    string Icon = "");