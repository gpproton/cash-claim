using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.PaymentModule;

public class PaymentService : GenericService<ServerContext, PaymentEntity, Payment> {
    public PaymentService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}