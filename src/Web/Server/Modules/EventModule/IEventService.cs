using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.EventModule;

public interface IEventService {
    Task<PagedResponse<List<EventResponse>>> GetRecentAsync();
    Task<PagedResponse<List<EventResponse>>> GetHistoryAsync(EventFilter filter);
    Task<PagedResponse<List<EventResponse>>> GetAccountAuditAsync();
    Task<Response<bool>> ClearOld();
}