namespace XClaim.Common.Dtos;

public record CompanyDto {
    public CompanyDto(string shortName, string? fullName, string? email, UserDto? manager) {
        ShortName = shortName;
        FullName = fullName;
        Email = email;
        Manager = manager;
    }

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string ShortName { get; set; } = String.Empty;
    public string? FullName { get; set; } = String.Empty;
    public string? Email { get; set; } = String.Empty;
    public UserDto? Manager { get; set; }
}