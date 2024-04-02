using System.ComponentModel.DataAnnotations;
using CashClaim.Common.Base;

namespace CashClaim.Service.Entities;

[GenerateAutoFilter("CashClaim.Service.Filters")]
public sealed class BankAccountEntity : TimedEntity {
    public string FullName { get; set; } = string.Empty;
    public BankEntity? Bank { get; set; }
    public Guid? BankId { get; set; }
    public UserEntity? Owner { get; set; }
    public Guid? OwnerId { get; set; }
    [Required]
    [MaxLength(20)]
    public string? Number { get; set; }
    [MaxLength(1024)]
    public string? Description { get; set; }
}