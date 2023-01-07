using Microsoft.EntityFrameworkCore;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryRepository : ICategoryRepository {
    private readonly ServerContext _ctx;

    public CategoryRepository(ServerContext ctx) {
        _ctx = ctx;
    }

    public async Task<List<CategoryEntity>> GetAll() {
        return await _ctx.Categories.ToListAsync();
    }
    
    public async Task<CategoryEntity?> GetById(Guid id) =>
        await _ctx.Categories.FindAsync(id);

    public async Task Create(CategoryEntity category) {
        await _ctx.Categories.AddAsync(category);
        await _ctx.SaveChangesAsync();
    }

    public async Task<CategoryEntity?> Modify(Guid id, CategoryEntity category) {
        var item = await _ctx.Categories.FindAsync(id);
        if (item is null) return null;
        _ctx.Update(category);
        await _ctx.SaveChangesAsync();
        return category;
    }
    
    public async Task<CategoryEntity?> Delete(Guid id) {
        var item = await _ctx.Categories.FindAsync(id);
        if (item == null) return null;

        _ctx.Categories.Remove(item);
        await _ctx.SaveChangesAsync();
        return item;
    }
}