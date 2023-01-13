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

    public async Task<IList<TResponse>> GetAllAsync(FilterBase? filter) {
        var values = filter is null ?
            await _ctx.Set<TEntity>().ToListAsync() :
            await _ctx.Set<TEntity>().ApplyFilter(filter).ToListAsync();
        return _mapper.Map<List<TResponse>>(values);
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
}