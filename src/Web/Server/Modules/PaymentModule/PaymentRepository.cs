using XClaim.Common.Entities;

namespace XClaim.Web.Server.Modules.PaymentModule;

public class PaymentRepository : IPaymentRepository {
    public Task<List<PaymentEntity>> GetAll() {
        throw new NotImplementedException();
    }

    public Task<PaymentEntity?> Update(Guid id) {
        throw new NotImplementedException();
    }

    public Task Create(PaymentEntity claim) {
        throw new NotImplementedException();
    }

    public Task Approve(PaymentEntity claim, UserEntity by) {
        throw new NotImplementedException();
    }
}