using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.ServerModule;

public interface IServerService {
    Task<Response<ServerStateResponse>> GetAsync();
    Task<Response<ServerStateResponse>> UpdateAsync(ServerResponse server);
}