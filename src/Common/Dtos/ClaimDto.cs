namespace XClaim.Common.Dtos;

public record ClaimDto(string Name, string Category, decimal Amount, DateTime Time, string Notes = "", string Icon = "");
