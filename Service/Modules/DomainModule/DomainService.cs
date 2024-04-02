using AutoMapper;
using CashClaim.Common.Dtos;
using CashClaim.Service.Data;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.DomainModule;

public sealed class DomainService : GenericService<ServerContext, DomainEntity, DomainResponse> {
    public DomainService(ServerContext ctx, IMapper mapper, ILogger<DomainService> logger) : base(ctx, mapper, logger) { }
}