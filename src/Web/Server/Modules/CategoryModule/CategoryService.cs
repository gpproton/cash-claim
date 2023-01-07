using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryService : ICategoryRepository {
    private readonly ServerContext _ctx;
    private readonly IMapper _mapper;

    public CategoryService(ServerContext ctx, IMapper mapper) {
        _ctx = ctx;
        _mapper = mapper;
    }

    public async Task<List<Category>> GetAll() {
        var items = await _ctx.Categories.ToListAsync();
        return _mapper.Map<List<Category>>(items);
    }
    
    public async Task<Category?> GetById(Guid id) {
        var item = await _ctx.Categories.FindAsync(id);
        return _mapper.Map<Category>(item);
    }

    public async Task<Category> Create(Category category) {
        var value = _mapper.Map<CategoryEntity>(category);
        await _ctx.Categories.AddAsync(value);
        await _ctx.SaveChangesAsync();

        return _mapper.Map<Category>(value);
    }

    public async Task<Category?> Modify(Category category) {
        var item = await _ctx.Categories.FindAsync(category.Id);
        if (item is null) return null;
        _mapper.Map(category, item);
        _ctx.Update(item);
        await _ctx.SaveChangesAsync();
        
        return _mapper.Map<Category>(item);
    }
    
    public async Task<Category?> Delete(Guid id) {
        var item = await _ctx.Categories.FindAsync(id);
        if (item == null) return null;
        _ctx.Categories.Remove(item);
        await _ctx.SaveChangesAsync();
        
        return _mapper.Map<Category>(item);
    }
}