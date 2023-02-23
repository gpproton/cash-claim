using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;
using XClaim.Common.Helpers;
using XClaim.Common.Wrappers;

namespace XClaim.Web.Server.Modules;

public abstract class GenericService<TContext, TEntity, TResponse> : IService<TContext, TEntity, TResponse>
    where TContext : DbContext
    where TEntity : class, IBaseEntity
    where TResponse : BaseResponse {

    protected readonly TContext _ctx;
    protected readonly IMapper _mapper;
    protected readonly ILogger<IService<TContext, TEntity, TResponse>> _logger;

    protected GenericService(TContext ctx, IMapper mapper, ILogger<IService<TContext, TEntity, TResponse>> logger) {
        _ctx = ctx;
        _mapper = mapper;
        _logger = logger;
    }

    public virtual async Task<PagedResponse<List<TResponse>>> GetAllAsync(PaginationFilterBase responseFilter) {
        var result = new PagedResponse<List<TResponse>>();
        var query = _ctx.Set<TEntity>();
        try {
            var count = await query.CountAsync();
            var data = await query.ApplyFilter(responseFilter).ToListAsync();
            var response = _mapper.Map<List<TResponse>>(data);
            var filter = new PaginationFilter {
                Page = responseFilter.Page,
                PerPage = responseFilter.PerPage
            };
            result = new PagedResponse<List<TResponse>>(response, count, filter) {
                Succeeded = true
            };
        }
        catch (Exception e) {
            result.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return result;
    }

    public virtual async Task<Response<TResponse?>> GetByIdAsync(Guid id) {
        var response = new Response<TResponse?>();
        try {
            var item = await _ctx.Set<TEntity>().FindAsync(id);
            var data = _mapper.Map<TResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    public async Task<Response<TResponse>> CreateAsync(TResponse value) {
        var response = new Response<TResponse>();
        try {
            var item = _mapper.Map<TEntity>(value);
            await _ctx.Set<TEntity>().AddAsync(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<TResponse>(item);
            response = new Response<TResponse>(data!) {
                Succeeded = data != null
            };
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }

    public async Task<Response<TResponse?>> UpdateAsync(TResponse value) {
        var response = new Response<TResponse?>();
        try {
            var item = await _ctx.Set<TEntity>().FindAsync(value.Id);
            if (item is null) return response;
            _mapper.Map(value, item);
            _ctx.Update(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<TResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        return response;
    }

    public async Task<Response<TResponse?>> DeleteAsync(Guid id) {
        var response = new Response<TResponse?>();
        try {
            var item = await _ctx.Set<TEntity>().FindAsync(id);
            if (item == null) return response;
            _ctx.Set<TEntity>().Remove(item);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<TResponse>(item);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        
        return response;
    }

    public async Task<Response<List<TResponse>?>> DeleteRangeAsync(List<Guid> ids) {
        var response = new Response<List<TResponse>?>();
        try {
            var items = _ctx.Set<TEntity>()
            .Where(f => ids.Contains(f.Id)).ToList();
            _ctx.Set<TEntity>().RemoveRange(items);
            await _ctx.SaveChangesAsync();
            var data = _mapper.Map<List<TResponse>>(items);
            response.Data = data;
            response.Succeeded = data != null;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
}