using System.Security.Claims;
using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using XClaim.Common.Dtos;
using XClaim.Web.Server.Data;
using XClaim.Web.Server.Entities;

namespace XClaim.Web.Server.Helpers;

public sealed class IdentityHelper {
    
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ServerContext _ctx;

    public IdentityHelper(IHttpContextAccessor contextAccessor, ServerContext ctx) {
        _contextAccessor = contextAccessor;
        _ctx = ctx;
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

    public async Task<UserEntity> GetUser() => default!;
    
    public async Task<UserEntity> GetManager() => default!;
    
    public async Task<bool> HasManager() => default!;
    
    public async Task<CompanyEntity> GetCompany() => default!;
    
    public async Task<TeamEntity> GetTeam() => default!;
}