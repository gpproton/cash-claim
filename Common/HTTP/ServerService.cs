using CashClaim.Common.Dtos;
using CashClaim.Common.Service;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public class ServerService : IServerService {
    private const string RootApi = "api/v1/server";
    private readonly IHttpService _http;
    public ServerService(IHttpService http) {
        _http = http;
    }

    public async Task<Response<ServerStateResponse>> GetAsync() {
        return await _http.Get<Response<ServerStateResponse>>(RootApi);
    }
    public async Task<Response<ServerStateResponse>> UpdateAsync(ServerResponse server) {
        return await _http.Put<Response<ServerStateResponse>>(RootApi, server);
    }
}