using CashClaim.Common.Dtos;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public interface IUserService {
    Task<PagedResponse<List<UserResponse>>> GetAllAsync(object? query = null);

    Task<PagedResponse<List<UserResponse>>> GetManagersAsync(object? query = null);

    Task<Response<UserResponse>> GetByIdAsync(Guid id);

    Task<Response<UserResponse>> RegistrationAsync(UserResponse user);

    Task<Response<UserResponse>> UpdateAsync(UserResponse user);

    Task<Response<UserResponse>> ArchiveAsync(Guid id);

    Task<Response<List<UserResponse>>> ArchiveRangeAsync(List<Guid> ids);
    Task<Response<TransferRequestResponse?>> GetTransferAsync();
    Task<PagedResponse<List<TransferRequestItem>>> GetAllTransferAsync(object? query = null);
    Task<Response<TransferRequestResponse>> CreateTransferAsync(TransferRequestResponse transfer);
    Task<Response<TransferRequestResponse>> ApproveTransferAsync(Guid id);
    Task<Response<TransferRequestResponse>> ArchiveTransferAsync(Guid id);
}