using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CashClaim.Common.Base;

namespace CashClaim.Service.Entities;

[Index(nameof(Name), IsUnique = true)]
[GenerateAutoFilter("CashClaim.Service.Filters")]
public class BankEntity : TimedEntity {
    [MaxLength(128)]
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string SwiftCode { get; set; } = string.Empty;
    public bool Active { get; set; }
}