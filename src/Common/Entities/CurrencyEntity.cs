using XClaim.Common.Base;

namespace XClaim.Common.Entities;

public class CurrencyEntity : BaseEntity {
    public string Name { get; set; }

    public string Symbol { get; set; }
}