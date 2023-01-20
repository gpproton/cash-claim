using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.PaymentModule;

public class PaymentService : GenericService<ServerContext, PaymentEntity, PaymentResponse> {
    public PaymentService(ServerContext ctx, IMapper mapper, ILogger<PaymentService> logger) : base(ctx, mapper, logger) { }
}