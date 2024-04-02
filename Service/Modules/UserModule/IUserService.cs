using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules.UserModule;

public interface IUserService {
    public Task<Response<UserResponse?>> GetByEmailAsync(string email);
    public Task<PagedResponse<List<UserResponse>>> GetAllAsync(UserFilter responseFilter);
    Task<Response<TransferRequestResponse?>> GetTransferAsync();
    Task<Response<TransferRequestResponse>> CreateTransferAsync(TransferRequestResponse value);
    Task<PagedResponse<List<TransferRequestItem>>> GetAllTransferAsync(TransferRequestFilter filter);
    Task<Response<TransferRequestResponse?>> ApproveTransferAsync(Guid id);
    Task<Response<TransferRequestResponse?>> ArchiveTransferAsync(Guid id);
}