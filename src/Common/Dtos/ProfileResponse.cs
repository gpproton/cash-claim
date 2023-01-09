using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class ProfileResponse : BaseResponse {
    public ProfileResponse(string email, string fullName, string phone, UserPermission permission = UserPermission.Standard, decimal balance = 0, TeamResponse teamResponse = default!) {
        Email = email;
        FullName = fullName;
        Phone = phone;
        Permission = permission;
        Balance = balance;
        TeamResponse = teamResponse;
    }

    public string Email { get; set; }
    public string FullName { get; set; }
    public string Phone { get; set; }
    public UserPermission Permission { get; set; }
    public decimal? Balance { get; set; }
    public TeamResponse? TeamResponse { get; set; }
}