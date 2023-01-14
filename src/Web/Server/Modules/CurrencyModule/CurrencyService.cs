using AutoMapper;
using XClaim.Common.Dtos;
using XClaim.Common.Entities;
using XClaim.Web.Server.Data;

namespace XClaim.Web.Server.Modules.CurrencyModule;

public class CurrencyService : GenericService<ServerContext, CurrencyEntity, CurrencyResponse> {
public CurrencyService(ServerContext ctx, IMapper mapper) : base(ctx, mapper) { }
}