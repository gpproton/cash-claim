using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record UserDto {
    public UserDto(string email, string? phone, string? firstName, string? lastName, decimal? balance, UserPermission permission, CompanyDto? company, CompanyDto? companyManaged, UserDto? manager, TeamDto? team, TeamDto? teamManaged, BankAccountDto? bankAccount, bool verified, string? token) {
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

    public Guid? Id { get; set; } = Guid.NewGuid();
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public decimal? Balance { get; set; }
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public CompanyDto? Company { get; set; }
    public CompanyDto? CompanyManaged { get; set; }
    public UserDto? Manager { get; set; }
    public TeamDto? Team { get; set; }
    public TeamDto? TeamManaged { get; set; }
    public BankAccountDto? BankAccount { get; set; }
    public bool Verified { get; set; }
    public string? Token { get; set; }
}