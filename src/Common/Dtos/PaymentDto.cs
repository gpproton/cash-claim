namespace XClaim.Common.Dtos;

public record PaymentDto(Guid id, string Name, string Category, decimal Amount, DateTime Time, string Status = "Completed",
    string Icon = "");