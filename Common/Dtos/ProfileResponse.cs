using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Common.Dtos;

public class ProfileResponse : BaseResponse {
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;

    public string FullName {
        get {
            return $"{FirstName} {LastName}";
        }
    }

    public string Phone { get; set; } = string.Empty;
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public decimal Balance { get; set; }
    public TeamResponse? Team { get; set; }
}