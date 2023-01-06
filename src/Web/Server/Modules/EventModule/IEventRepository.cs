using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public interface IEventRepository {
    public Task<List<EventEntity>> GetRecent();
    Task<EventEntity?> GetById(Guid id);
    Task ClearOld();
}