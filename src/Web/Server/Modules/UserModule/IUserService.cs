using XClaim.Common.Dtos;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.UserModule;

public interface IUserService {
    public Task<Response<UserResponse?>> GetByEmailAsync(string email);
    public Task<PagedResponse<List<UserResponse>>> GetAllAsync(UserFilter responseFilter);
    Task<Response<TransferRequestResponse?>> GetTransferAsync();
    Task<Response<TransferRequestResponse>> CreateTransferAsync();
    Task<PagedResponse<List<TransferRequestResponse>>> GetAllTransferAsync(TransferRequestFilter filter);
    Task<Response<TransferRequestResponse?>> ApproveTransferAsync(TransferRequestResponse transfer);
    Task<Response<TransferRequestResponse?>> ArchiveTransferAsync(Guid id);
}