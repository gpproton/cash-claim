
using AutoFilterer.Types;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Modules;

public interface IService<TContext, TEntity, TResponse>
    where TContext : DbContext
    where TEntity : IBaseEntity
    where TResponse : BaseResponse {
    Task<IList<TResponse>> GetAllAsync(FilterBase? filter);

    Task<TResponse> GetByIdAsync(Guid id);

    Task<TResponse> CreateAsync(TResponse value);

    Task<TResponse?> UpdateAsync(TResponse value);

    Task<TResponse?> DeleteAsync(Guid id);
}