using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

[GenerateAutoFilter]
public class UserResponse : BaseResponse {
    public UserResponse(string email, string? phone, string? firstName, string? lastName, decimal? balance, UserPermission permission, CompanyResponse? company, CompanyResponse? companyManaged, UserResponse? manager, TeamResponse? team, TeamResponse? teamManaged, BankAccount? bankAccount, bool verified, string? token) {
        Email = email;
        Phone = phone;
        FirstName = firstName;
        LastName = lastName;
        Balance = balance;
        Permission = permission;
        Company = company;
        CompanyManaged = companyManaged;
        Manager = manager;
        Team = team;
        TeamManaged = teamManaged;
        BankAccount = bankAccount;
        Verified = verified;
        Token = token;
    }

    public string Email { get; set; }
    public string? Phone { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string FullName {
        get { return $"{FirstName} {LastName}"; }
    }
    public decimal? Balance { get; set; }
    public UserPermission Permission { get; set; }
    public CompanyResponse? Company { get; set; }
    public CompanyResponse? CompanyManaged { get; set; }
    public UserResponse? Manager { get; set; }
    public TeamResponse? Team { get; set; }
    public TeamResponse? TeamManaged { get; set; }
    public BankAccount? BankAccount { get; set; }
    public bool Verified { get; set; }
    public string? Token { get; set; }
}