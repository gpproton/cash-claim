namespace XClaim.Web.Server.Modules.EventModule;

public interface IEventService {
    Task ClearOld();
}