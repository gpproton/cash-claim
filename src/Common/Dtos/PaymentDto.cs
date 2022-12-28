namespace XClaim.Common.Dtos;

public record PaymentDto(string Name, string Category, decimal Amount, DateTime Time, string Status = "Completed",
    string Icon = "");