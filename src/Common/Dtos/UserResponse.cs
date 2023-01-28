using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public class UserResponse : BaseResponse {
    public string Identifier { get; set; } = string.Empty;
    public string Email { get; set; } = String.Empty;
    public string Phone { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string FullName {
        get { return $"{FirstName} {LastName}"; }
    }
    public decimal Balance { get; set; }
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public CompanyResponse? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public CompanyResponse? CompanyManaged { get; set; }
    public TeamResponse? Team { get; set; }
    public Guid? TeamId { get; set; }
    public TeamResponse? TeamManaged { get; set; }
    public BankAccountResponse? BankAccount { get; set; }
    public CurrencyResponse? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
    public bool Active { get; set; }
    public string Token { get; set; } = String.Empty;
    public string? Image { get; set; }
}