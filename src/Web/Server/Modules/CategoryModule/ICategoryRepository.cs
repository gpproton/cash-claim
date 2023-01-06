using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.CategoryModule;

public interface ICategoryRepository {
    public Task<List<CategoryEntity>> GetAll();
    Task Create(CategoryEntity category);
    Task Modify(CategoryEntity category);
    Task<bool> Delete(Guid id);
    Task<CategoryEntity?> GetById(Guid id);
}