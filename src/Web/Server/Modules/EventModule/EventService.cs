using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public class EventService : GenericService<ServerContext, EventEntity, EventResponse>, IEventService {
    public EventService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
    public Task ClearOld() {
        throw new NotImplementedException();
    }
}