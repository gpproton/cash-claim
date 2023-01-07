using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.CompanyModule;

public class CompanyService : ICompanyRepository {
    public Task<List<CompanyEntity>> GetAll() {
        throw new NotImplementedException();
    }

    public Task Create(CompanyEntity company) {
        throw new NotImplementedException();
    }

    public Task Modify(CompanyEntity company) {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(Guid id) {
        throw new NotImplementedException();
    }

    public Task<CompanyEntity?> GetById(Guid id) {
        throw new NotImplementedException();
    }
}