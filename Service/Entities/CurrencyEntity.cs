using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using CashClaim.Common.Base;

namespace CashClaim.Service.Entities;

[Index(nameof(Name), IsUnique = true)]
[Index(nameof(Code), IsUnique = true)]
public class CurrencyEntity : TimedEntity {
    public string Name { get; set; } = string.Empty;
    [MaxLength(1)]
    public string? Symbol { get; set; } = string.Empty;
    [MaxLength(3)]
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
}