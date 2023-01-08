using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.EventModule;

public interface IEventService {
    Task ClearOld();
}