using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public record Company : BaseResponse {
    public Company(string shortName, string? fullName, string? email, User? manager) {
        ShortName = shortName;
        FullName = fullName;
        Email = email;
        Manager = manager;
    }

    public string ShortName { get; set; } = String.Empty;
    public string? FullName { get; set; } = String.Empty;
    public string? Email { get; set; } = String.Empty;
    public User? Manager { get; set; }
}