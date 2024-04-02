using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class CurrencyResponse : BaseResponse {
    public string Name { get; set; } = string.Empty;

    public string Symbol { get; set; } = string.Empty;
    public string Code { get; set; } = string.Empty;
    public decimal Rate { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
}