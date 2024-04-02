using AutoMapper;
using CashClaim.Common.Dtos;
using CashClaim.Service.Data;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.BankModule;

public sealed class BankService : GenericService<ServerContext, BankEntity, BankResponse>, IBankService {
    public BankService(ServerContext ctx, IMapper mapper, ILogger<BankService> logger) : base(ctx, mapper, logger) { }
}