using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface IServerService {
    Task<Response<ServerStateResponse>> GetAsync();
    Task<Response<ServerStateResponse>> UpdateAsync(ServerResponse server);
}