using System.ComponentModel.DataAnnotations;
using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Common.Entities;

public sealed class UserEntity : BaseEntity {
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Balance { get; set; }
    public UserPermission Permission { get; set; } = UserPermission.Standard;
    public CompanyEntity? Company { get; set; }
    public Guid? CompanyId { get; set; }
    public CompanyEntity? CompanyManaged { get; set; }
    public Guid? CompanyManagedId { get; set; }
    public UserEntity? Manager { get; set; }
    public Guid? ManagerId { get; set; }
    public TeamEntity? Team { get; set; }
    public Guid? TeamId { get; set; }
    public TeamEntity? TeamManaged { get; set; }
    public Guid? TeamManagedId { get; set; }
    public BankAccountEntity? BankAccount { get; set; }
    public Guid? BankAccountId { get; set; }
    public bool Verified { get; set; }
    public string? Token { get; set; }
}