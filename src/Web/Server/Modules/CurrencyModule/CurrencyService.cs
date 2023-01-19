using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.CurrencyModule;

public class CurrencyService : GenericService<ServerContext, CurrencyEntity, CurrencyResponse> {
public CurrencyService(ServerContext ctx, IMapper mapper, ILogger<CurrencyService> logger) : base(ctx, mapper, logger) { }
}