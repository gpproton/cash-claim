using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class ProfileResponse : BaseResponse {
    public ProfileResponse(string email, string firstName, string lastname, string phone, UserPermission permission = UserPermission.Standard, decimal balance = 0, TeamResponse teamResponse = default!) {
        Email = email;
        FirstName = firstName;
        LastName = lastname;
        Phone = phone;
        Permission = permission;
        Balance = balance;
        TeamResponse = teamResponse;
    }

    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public string FullName {
        get {
            return $"{FirstName} {LastName}";
        }
    }

    public string Phone { get; set; }
    public UserPermission Permission { get; set; }
    public decimal? Balance { get; set; }
    public TeamResponse? TeamResponse { get; set; }
}