using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class CompanyResponse : BaseResponse {
    public CompanyResponse(string shortName, string? fullName, string? email, UserResponse? manager) {
        ShortName = shortName;
        FullName = fullName;
        Email = email;
        Manager = manager;
    }

    public string ShortName { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public UserResponse? Manager { get; set; }
}