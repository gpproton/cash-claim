using CashClaim.Common.Base;
using CashClaim.Common.Enums;

namespace CashClaim.Common.Dtos;

public class EventResponse : BaseResponse {
    public EventType Type { get; set; } = EventType.Claim;
    public ClaimResponse? Claim { get; set; }
    public PaymentResponse? Payment { get; set; }
    public string Description { get; set; } = string.Empty;
}