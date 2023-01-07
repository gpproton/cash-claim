using XClaim.Common.Dtos;

namespace XClaim.Web.Server.Modules.CategoryModule;

public interface ICategoryRepository {
    Task<List<Category>> GetAll();
    Task<Category> Create(Category category);
    Task<Category?> Modify(Category category);
    Task<Category?> Delete(Guid id);
    Task<Category?> GetById(Guid id);
}