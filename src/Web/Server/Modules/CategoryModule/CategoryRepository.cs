using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.CategoryModule;

public class CategoryRepository : ICategoryRepository {
    public Task<List<CategoryEntity>> GetAll() {
        throw new NotImplementedException();
    }

    public Task Create(CategoryEntity category) {
        throw new NotImplementedException();
    }

    public Task Modify(CategoryEntity category) {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id) {
        throw new NotImplementedException();
    }

    public Task<CategoryEntity?> GetById(Guid id) {
        throw new NotImplementedException();
    }
}