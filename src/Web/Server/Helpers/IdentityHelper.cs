using System.Security.Claims;
using AutoMapper;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;
using XClaim.Web.Server.Extensions;

namespace XClaim.Web.Server.Helpers;

public sealed class IdentityHelper {

    private const string UserKey = "identity-user-state";
    private const string ManagerKey = "identity-manager-state";
    
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ServerContext _ctx;
    private readonly IMapper _mapper;

    public IdentityHelper(IHttpContextAccessor contextAccessor, ServerContext ctx, IMapper mapper) {
        _contextAccessor = contextAccessor;
        _ctx = ctx;
        _mapper = mapper;
    }

    private ClaimsPrincipal? Claim {
        get { return _contextAccessor?.HttpContext?.User; }
    }

    public string? NameIdentifier {
        get {
            return this.Claim!.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }

    public bool IsAuthenticated {
        get {
            return this.Claim?.Identity?.IsAuthenticated ?? false;
        }
    }

    public async Task<AuthResponse?> GetAuthProfile() {
        var ctx = _contextAccessor!.HttpContext;
        var auth = await ctx!.AuthenticateAsync("Microsoft");
        
        // Get required options
        var email = this.Claim!.FindFirstValue(ClaimTypes.Email) ?? "";
        var fullName = this.Claim!.FindFirstValue(ClaimTypes.Name) ?? "";
        var phone = this.Claim!.FindFirstValue(ClaimTypes.HomePhone) ?? "";
        var token = auth?.Properties?.GetTokenValue("access_token");
        var expiry = (auth?.Properties?.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToDateTimeFromEpoch();
        var expireIn = (int)expiry.Subtract(DateTime.Now).TotalSeconds;
        
        var names = fullName.Split(" ");
        var data = new UserResponse {
            Identifier = this.NameIdentifier ?? "",
            Email = email,
            FirstName = names[0],
            LastName = names[^1],
            Phone = phone
        };
        
        return new AuthResponse {
            ExpiryTimeStamp = expiry,
            ExpiresIn = expireIn,
            Token = token,
            Message = "Success",
            UserName = fullName,
            Data = data
        };
    }

    private async Task<UserResponse?> GetByIdentifierAsync(string identifier) {
        var query = _ctx.Users.Where(x => x.DeletedAt == null)
                    .Where(x => x.Identifier == identifier);

        return await this.GetUserEntity(query);
    }
    
    private async Task<UserResponse?> GetByIdAsync(Guid id) {
        var query = _ctx.Users.Where(x => x.DeletedAt == null)
        .Where(x => x.Id == id);

        return await this.GetUserEntity(query);
    }
    
    private async Task<UserResponse?> GetUserEntity (IQueryable<UserEntity> queryable) {
        var ctx = _contextAccessor!.HttpContext;
        var cache = ctx!.Session.Get<UserResponse>(UserKey);
        if (cache != null) {
            return cache;
        }

        var query = await queryable.Include(x => x.Company)
                    .Include(x => x.Team)
                    .Include(x => x.Currency)
                    .FirstOrDefaultAsync();
        var result = _mapper.Map<UserResponse>(query);
        ctx!.Session.Set(UserKey, result);

        return result;
    }

    public async Task<UserResponse?> GetUser() {
        var id = this.NameIdentifier;
        var response = await this.GetByIdentifierAsync(id!);

        return response;
    }

    public async Task<CompanyResponse?> GetCompany() {
        var user = await this.GetUser();

        return user?.Company;
    }

    public async Task<TeamResponse?> GetTeam() {
        var user = await this.GetUser();

        return user?.Team;
    }
    
    public async Task<UserResponse?> GetManager() {
        var ctx = _contextAccessor!.HttpContext;
        var cache = ctx!.Session.Get<UserResponse>(ManagerKey);
        if (cache != null) {
            return cache;
        }
        
        var team = await this.GetTeam();
        if (team!.ManagerId == null) return null;
        Guid managerId = ((Guid)team!.ManagerId!);
        var manager = await this.GetByIdAsync(managerId);
        ctx!.Session.Set(ManagerKey, manager);

        return manager;
    }
    
    public async Task<bool> HasManager() => await this.GetManager() != null;
}