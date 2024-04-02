using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class BankResponse : BaseResponse {
    public string Name { get; set; } = string.Empty;
    public string SwiftCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Active { get; set; }
}