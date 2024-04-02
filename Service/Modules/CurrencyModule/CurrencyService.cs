using AutoMapper;
using CashClaim.Common.Dtos;
using CashClaim.Service.Data;
using CashClaim.Service.Entities;

namespace CashClaim.Service.Modules.CurrencyModule;

public sealed class CurrencyService : GenericService<ServerContext, CurrencyEntity, CurrencyResponse> {
    public CurrencyService(ServerContext ctx, IMapper mapper, ILogger<CurrencyService> logger) : base(ctx, mapper, logger) { }
}