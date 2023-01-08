using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.EventModule;

public class EventService : GenericService<ServerContext, EventEntity, EventResponse>, IEventService {
    public EventService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
    public Task ClearOld() {
        throw new NotImplementedException();
    }
}