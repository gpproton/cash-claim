namespace XClaim.Common.Dtos;

public record Company {
    public Company(string shortName, string? fullName, string? email, User? manager) {
        ShortName = shortName;
        FullName = fullName;
        Email = email;
        Manager = manager;
    }

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string ShortName { get; set; } = String.Empty;
    public string? FullName { get; set; } = String.Empty;
    public string? Email { get; set; } = String.Empty;
    public User? Manager { get; set; }
}