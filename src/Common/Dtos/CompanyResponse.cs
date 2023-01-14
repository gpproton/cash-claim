using XClaim.Common.Base;

namespace XClaim.Common.Dtos;

public class CompanyResponse : BaseResponse {
    public string ShortName { get; set; } = string.Empty;
    public string FullName { get; set; } = string.Empty;
    public string AdminEmail { get; set; } = string.Empty;
    public UserResponse? Manager { get; set; }
}