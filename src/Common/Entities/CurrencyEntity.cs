using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Common.Entities;

[Index(nameof(Name), IsUnique = true)]
public class CurrencyEntity : BaseEntity {
    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;
}