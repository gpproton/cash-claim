using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Service.Entities;

[Index(nameof(Email), IsUnique = true)]
[Index(nameof(Identifier), IsUnique = true)]
public sealed class UserEntity : TimedEntity {
    public string Identifier { get; set; } = string.Empty;
    [MaxLength(256)]
    public string Email { get; set; } = string.Empty;
    public string? ProfileImage { get; set; }
    [MaxLength(64)]
    public string Phone { get; set; } = string.Empty;
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
    public TeamEntity? Team { get; set; }
    public Guid? TeamId { get; set; }
    public TeamEntity? TeamManaged { get; set; }
    public Guid? TeamManagedId { get; set; }
    public BankAccountEntity? BankAccount { get; set; }
    public NotificationEntity? Notification { get; set; }
    public SettingEntity? Setting { get; set; }
    public CurrencyEntity? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
    public bool Active { get; set; }
    [MaxLength(128)]
    public string? Token { get; set; }
    public string? Image { get; set; }
}