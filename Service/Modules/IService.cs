
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;
using CashClaim.Common.Base;
using CashClaim.Common.Wrappers;

namespace CashClaim.Service.Modules;

public interface IService<TContext, TEntity, TResponse>
    where TContext : DbContext
    where TEntity : IBaseEntity
    where TResponse : BaseResponse {
    Task<PagedResponse<List<TResponse>>> GetAllAsync(PaginationFilterBase filter);

    Task<Response<TResponse?>> GetByIdAsync(Guid id);

    Task<Response<TResponse>> CreateAsync(TResponse value);

    Task<Response<TResponse?>> UpdateAsync(TResponse value);

    Task<Response<TResponse?>> DeleteAsync(Guid id);

    Task<Response<List<TResponse>?>> DeleteRangeAsync(List<Guid> ids);
}