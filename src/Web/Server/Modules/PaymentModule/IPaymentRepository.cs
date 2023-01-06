using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.PaymentModule;

public interface IPaymentRepository {
    public Task<List<PaymentEntity>> GetAll();
    Task<PaymentEntity?> Update(Guid id);
    Task Create(PaymentEntity claim);
    Task Approve(PaymentEntity claim, UserEntity by);
}