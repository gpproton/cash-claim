using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.BankModule;

public sealed class BankService : GenericService<ServerContext, BankEntity, BankResponse>, IBankService {
    public BankService(ServerContext ctx, IMapper mapper, ILogger<BankService> logger) : base(ctx, mapper, logger) { }
}