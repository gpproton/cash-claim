using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;
using XClaim.Common.Enums;

namespace XClaim.Web.Server.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Phone), IsUnique = true)]
[Index(nameof(UserName), IsUnique = true)]
public sealed class UserEntity : BaseEntity {
    [MaxLength(256)]
    public string Email { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }
    [MaxLength(64)]
    public string Phone { get; set; } = string.Empty;
    [MaxLength(128)]
    public string UserName { get; set; } = string.Empty;
    [MaxLength(128)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(128)]
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
    public bool Active { get; set; }
    [MaxLength(128)]
    public string? Token { get; set; }
    public string? Image { get; set; }
}