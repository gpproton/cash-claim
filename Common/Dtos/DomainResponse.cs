using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class DomainResponse : BaseResponse {
    public string Address { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string Description { get; set; } = string.Empty;
}