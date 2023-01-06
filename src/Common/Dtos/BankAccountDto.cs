namespace XClaim.Common.Dtos;

public record BankAccountDto {
    public BankAccountDto(Guid? id string? fullName, BankDto? bank, UserDto? owner, string? number, string? description) {
        Id = id;
        FullName = fullName;
        Bank = bank;
        Owner = owner;
        Number = number;
        Description = description;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public string? FullName { get; set; } = string.Empty;
    public BankDto? Bank { get; set; }
    public UserDto? Owner { get; set; }
    public string? Number { get; set; }
    public string? Description { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}