using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public sealed class EventService : GenericService<ServerContext, EventEntity, EventResponse>, IEventService {
    public EventService(ServerContext ctx, IMapper mapper, ILogger<EventService> logger) : base(ctx, mapper, logger) { }

    public async Task<PagedResponse<List<EventResponse>>> GetRecentAsync() {
        throw new NotImplementedException();
    }
    public async Task<PagedResponse<List<EventResponse>>> GetHistoryAsync(EventFilter filter) {
        throw new NotImplementedException();
    }
    public async Task<PagedResponse<List<EventResponse>>> GetAccountAuditAsync() {
        throw new NotImplementedException();
    }
    public async Task<Response<bool>> ClearOld() {
        throw new NotImplementedException();
    }
}