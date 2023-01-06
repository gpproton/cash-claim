namespace XClaim.Common.Dtos;

public record BankDto {
    public BankDto(string name) {
        Name = name;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}