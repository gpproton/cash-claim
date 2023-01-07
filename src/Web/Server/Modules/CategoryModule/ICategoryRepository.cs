using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.CategoryModule;

public interface ICategoryRepository {
    public Task<List<CategoryEntity>> GetAll();
    Task Create(CategoryEntity category);
    Task<CategoryEntity?> Modify(Guid id, CategoryEntity category);
    Task<CategoryEntity?> Delete(Guid id);
    Task<CategoryEntity?> GetById(Guid id);
}