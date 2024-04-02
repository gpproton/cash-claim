using CashClaim.Common.Dtos;
using CashClaim.Common.Service;
using CashClaim.Common.Wrappers;

namespace CashClaim.Common.HTTP;

public class UserService : IUserService {
    private const string RootApi = "api/v1/user";
    private readonly IHttpService _http;

    public UserService(IHttpService http) {
        _http = http;
    }
    public async Task<PagedResponse<List<UserResponse>>> GetAllAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<UserResponse>>>(RootApi, query);
    }
    public async Task<PagedResponse<List<UserResponse>>> GetManagersAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<UserResponse>>>(RootApi, query);
    }

    public async Task<Response<UserResponse>> GetByIdAsync(Guid id) {
        return await _http.Get<Response<UserResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<UserResponse>> RegistrationAsync(UserResponse user) {
        return await _http.Post<Response<UserResponse>>(RootApi, user);
    }
    public async Task<Response<UserResponse>> UpdateAsync(UserResponse user) {
        return await _http.Put<Response<UserResponse>>(RootApi, user);
    }
    public async Task<Response<UserResponse>> ArchiveAsync(Guid id) {
        return await _http.Delete<Response<UserResponse>>($"{RootApi}/{id}");
    }
    public async Task<Response<List<UserResponse>>> ArchiveRangeAsync(List<Guid> ids) {
        return await _http.Delete<Response<List<UserResponse>>>(RootApi, ids);
    }
    public async Task<PagedResponse<List<TransferRequestItem>>> GetAllTransferAsync(object? query = null) {
        return await _http.Get<PagedResponse<List<TransferRequestItem>>>($"{RootApi}/transfer", query);
    }
    public async Task<Response<TransferRequestResponse?>> GetTransferAsync() {
        return await _http.Get<Response<TransferRequestResponse?>>($"{RootApi}/transfer/profile");
    }
    public async Task<Response<TransferRequestResponse>> CreateTransferAsync(TransferRequestResponse transfer) {
        return await _http.Post<Response<TransferRequestResponse>>($"{RootApi}/transfer", transfer);
    }
    public async Task<Response<TransferRequestResponse>> ApproveTransferAsync(Guid id) {
        return await _http.Put<Response<TransferRequestResponse>>($"{RootApi}/transfer/{id}");
    }
    public async Task<Response<TransferRequestResponse>> ArchiveTransferAsync(Guid id) {
        return await _http.Delete<Response<TransferRequestResponse>>($"{RootApi}/transfer/{id}");
    }
}