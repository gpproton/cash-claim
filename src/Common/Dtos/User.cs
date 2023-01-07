using XClaim.Common.Enums;

namespace XClaim.Common.Dtos;

public record User {
    public User(string email, string? phone, string? firstName, string? lastName, decimal? balance, UserPermission permission, Company? company, Company? companyManaged, User? manager, Team? team, Team? teamManaged, BankAccount? bankAccount, bool verified, string? token) {
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

    public Guid? Id { get; set; }
    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
    public string Email { get; set; } = string.Empty;
    public string? Phone { get; set; } = string.Empty;
    public string? FirstName { get; set; } = string.Empty;
    public string? LastName { get; set; } = string.Empty;
    public string FullName {
        get { return $"{FirstName} {LastName}"; }
    }
    public decimal? Balance { get; set; }
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public Company? Company { get; set; }
    public Company? CompanyManaged { get; set; }
    public User? Manager { get; set; }
    public Team? Team { get; set; }
    public Team? TeamManaged { get; set; }
    public BankAccount? BankAccount { get; set; }
    public bool Verified { get; set; }
    public string? Token { get; set; }
}