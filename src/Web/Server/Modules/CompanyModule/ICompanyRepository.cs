using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.CompanyModule;

public interface ICompanyRepository {
    public Task<List<CompanyEntity>> GetAll();
    Task Create(CompanyEntity company);
    Task Modify(CompanyEntity company);
    Task<bool> Delete(Guid id);
    Task<CompanyEntity?> GetById(Guid id);
}