using AutoFilterer.Extensions;
using AutoFilterer.Types;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Base;

namespace XClaim.Web.Server.Modules;

public abstract class GenericService<TContext, TEntity, TResponse> : IService<TContext, TEntity, TResponse>
    where TContext : DbContext
    where TEntity : class, IBaseEntity
    where TResponse : BaseResponse {

    protected readonly TContext _ctx;
    protected readonly IMapper _mapper;

    protected GenericService(TContext ctx, IMapper mapper) {
        _ctx = ctx;
        _mapper = mapper;
    }

    public virtual async Task<IList<TResponse>> GetAllAsync(FilterBase? filter) {
        var query = _ctx.Set<TEntity>().Where(x => x.DeletedAt == null);
        var values = filter is null ?
                     query.ToListAsync() : query.ApplyFilter(filter).ToListAsync();
        return _mapper.Map<List<TResponse>>(await values);
    }

    public async Task<TResponse> GetByIdAsync(Guid id) {
        var item = await _ctx.Set<TEntity>().FindAsync(id);
        return _mapper.Map<TResponse>(item);
    }

    public async Task<TResponse> CreateAsync(TResponse value) {
        var map = _mapper.Map<TEntity>(value);
        await _ctx.Set<TEntity>().AddAsync(map);
        await _ctx.SaveChangesAsync();

        return _mapper.Map<TResponse>(map);
    }

    public async Task<TResponse?> UpdateAsync(TResponse value) {
        var item = await _ctx.Set<TEntity>().FindAsync(value.Id);
        if (item is null) return null;
        _mapper.Map(value, item);
        _ctx.Update(item);
        await _ctx.SaveChangesAsync();

        return _mapper.Map<TResponse>(item);
    }

    public async Task<TResponse?> DeleteAsync(Guid id) {
        var item = await _ctx.Set<TEntity>().FindAsync(id);
        if (item == null) return null;
        _ctx.Set<TEntity>().Remove(item);
        await _ctx.SaveChangesAsync();

        return _mapper.Map<TResponse>(item);
    }
    public async Task<List<TResponse>?> DeleteRangeAsync(List<Guid> ids) {
        var items = _ctx.Set<TEntity>()
        .Where(f => ids.Contains(f.Id)).ToList();
        _ctx.Set<TEntity>().RemoveRange(items);
        await _ctx.SaveChangesAsync();
        
        return _mapper.Map<List<TResponse>>(items);
    }
}