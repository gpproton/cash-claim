using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public class EventService : IEventRepository {
    public Task<List<EventEntity>> GetRecent() {
        throw new NotImplementedException();
    }

    public Task<EventEntity?> GetById(Guid id) {
        throw new NotImplementedException();
    }

    public Task ClearOld() {
        throw new NotImplementedException();
    }
}