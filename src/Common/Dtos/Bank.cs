namespace XClaim.Common.Dtos;

public record Bank {
    public Bank(string name) {
        Name = name;
    }

    public Guid? Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
}