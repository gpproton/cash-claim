using CashClaim.Common.Base;

namespace CashClaim.Common.Dtos;

public class ServerResponse : BaseResponse {
    public string ServiceName { get; set; } = string.Empty;
    public string AdminEmail { get; set; } = string.Empty;
    public bool MaintenanceMode { get; set; }
    public string MaintenanceText { get; set; } = string.Empty;
    public CurrencyResponse? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
}