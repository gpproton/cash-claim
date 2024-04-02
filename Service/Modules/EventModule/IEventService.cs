using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Service.Modules.EventModule;

public interface IEventService {
    Task<PagedResponse<List<EventResponse>>> GetRecentAsync();
    Task<PagedResponse<List<EventResponse>>> GetHistoryAsync(EventFilter filter);
    Task<PagedResponse<List<EventResponse>>> GetAccountAuditAsync();
    Task<Response<bool>> ClearOld();
}