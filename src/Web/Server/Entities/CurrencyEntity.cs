using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Entities;

[Index(nameof(Name), IsUnique = true)]
public class CurrencyEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;
    [MaxLength(4)]
    public string Symbol { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
}