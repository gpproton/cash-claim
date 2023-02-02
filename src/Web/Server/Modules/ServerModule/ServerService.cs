using AutoMapper;
using Microsoft.EntityFrameworkCore;
using XClaim.Common;
using XClaim.Common.Dtos;
using XClaim.Common.HTTP;
using XClaim.Common.Wrappers;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Modules.ServerModule;

public class ServerService : IServerService {
    
    private readonly ServerContext _ctx;
    private readonly IMapper _mapper;
    private readonly ILogger<ServerService> _logger;
    private readonly IConfiguration _configuration;

    private record ServerState(bool Online, ServerEntity Server);

    public ServerService(ServerContext ctx, IMapper mapper, ILogger<ServerService> logger, IConfiguration configuration) {
        _ctx = ctx;
        _mapper = mapper;
        _logger = logger;
        _configuration = configuration;
    }
    
    private async Task<ServerState> Get() {
        var name =_configuration.GetValue<string>("ServiceName") ?? SharedConst.ServiceName;
        var defaults = new ServerEntity() { ServiceName = name };
        var online = await _ctx.Server.AnyAsync();
        if (!online) return new ServerState(false, defaults);
        var result = (await _ctx.Server.Include(x => x.Currency)
                      .FirstOrDefaultAsync())!;

        return new ServerState(true, result);
    }

    public async Task<Response<ServerStateResponse>> GetAsync() {
        var response = new Response<ServerStateResponse> {
            Succeeded = true
        };
        try {
            var value = await this.Get();
            var db = _mapper.Map<ServerResponse>(value.Server);
            var data = new ServerStateResponse {
                Online = value.Online
            };
            _mapper.Map(db, data);
            response.Data = data;
        } catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }

        return response;
    }
    
    public async Task<Response<ServerStateResponse>> UpdateAsync(ServerResponse server) {
        var response = new Response<ServerStateResponse> {
            Succeeded = true
        };
        try {
            var value = await this.Get();
            if (!value.Online) return response;
            var item = value.Server;
            _mapper.Map(server, item);
            _ctx.Update(item);
            await _ctx.SaveChangesAsync();
            var db = _mapper.Map<ServerResponse>(item);
            var data = new ServerStateResponse {
                Online = value.Online
            };
            _mapper.Map(db, data);
            response.Data = data;
        }
        catch (Exception e) {
            response.Errors = new[] { e.ToString() };
            _logger.LogError(e.ToString());
        }
        return response;
    }
}