using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public sealed class EventService : GenericService<ServerContext, EventEntity, EventResponse>, IEventService {
    public EventService(ServerContext ctx, IMapper mapper, ILogger<EventService> logger) : base(ctx, mapper, logger) { }
    public Task ClearOld() {
        throw new NotImplementedException();
    }
}