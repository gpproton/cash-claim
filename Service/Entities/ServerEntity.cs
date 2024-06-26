using CashClaim.Common.Base;

namespace CashClaim.Service.Entities;

public class ServerEntity : BaseEntity {
    public string ServiceName { get; set; } = string.Empty;
    public string AdminEmail { get; set; } = string.Empty;
    public bool MaintenanceMode { get; set; }
    public string MaintenanceText { get; set; } = string.Empty;
    public CurrencyEntity? Currency { get; set; }
    public Guid? CurrencyId { get; set; }
}