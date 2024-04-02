using AutoMapper;
using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;
using CashClaim.Service.Data;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.EventModule;

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