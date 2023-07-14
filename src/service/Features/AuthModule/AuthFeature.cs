// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System.Net;
using System.Security.Claims;
using Axolotl.AspNet.Feature;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Nextended.Core.Extensions;
using XClaim.Common.Entity;

namespace XClaim.Service.Features.AuthModule;

public class AuthFeature : IFeature {
    public IServiceCollection RegisterModule(IServiceCollection services) {
        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Authentication";
        const string url = $"/identity";
        RouteGroupBuilder? group = endpoints.MapGroup(url).WithTags(name);

        group.MapGroup("/").MapIdentityApi<AccountEntity>();
        group.MapGet("/microsoft", ([FromQuery] string? redirect) => {
                string? redirectUri = Environment.GetEnvironmentVariable("ROOT_URI") ??
                                      (redirect.IsNullOrEmpty() ? Constants.RootApi : redirect);
                AuthenticationProperties props = new() {
                    IsPersistent = true,
                    RedirectUri = redirectUri
                };

                return Results.Challenge(props, new[] { MicrosoftAccountDefaults.AuthenticationScheme });
            }).WithName("SignIn")
            .WithOpenApi();

        group.MapPost("/sign-out", async (HttpRequest request) => {
                await request.HttpContext.SignOutAsync();
                return Results.Ok(true);
            }).WithName("SignOut")
            .WithOpenApi();

        group.MapGet("/microsoft-mobile", async (HttpRequest request, [FromQuery] string? scheme) => {
            string? schemeValue = scheme.IsNullOrEmpty() ? "Microsoft" : scheme;
            AuthenticateResult? auth = await request.HttpContext.AuthenticateAsync(schemeValue);
            const string callbackScheme = "xclaim";

            if (!auth.Succeeded
                || auth?.Principal == null
                || !auth.Principal.Identities.Any(id => id.IsAuthenticated)
                || string.IsNullOrEmpty(auth.Properties.GetTokenValue("access_token"))) {
                await request.HttpContext.ChallengeAsync(schemeValue);
            }
            else {
                IEnumerable<Claim>? claims = auth.Principal.Identities.FirstOrDefault()?.Claims;
                string? address = claims?.FirstOrDefault(c => c.Type == ClaimTypes.Email)
                    ?.Value;
                if (address != null) {
                    string? emailAddress = address;
                    Dictionary<string, string>? qs = new() {
                        { "access_token", auth.Properties.GetTokenValue("access_token") },
                        { "refresh_token", auth.Properties.GetTokenValue("refresh_token") ?? string.Empty },
                        { "expires_in", (auth.Properties.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToString() },
                        { "email", emailAddress }
                    };

                    string? redirectUrl = callbackScheme + "://#" + string.Join(
                        "&",
                        qs.Where(kvp => !string.IsNullOrEmpty(kvp.Value) && kvp.Value != "-1")
                            .Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));

                    request.HttpContext.Response.Redirect(redirectUrl);
                }
            }
        }).WithName("MobileSignIn").WithOpenApi();

        group.MapGet("/test-auth", (ClaimsPrincipal user) => $"Hello, {user.Identity?.Name}!").RequireAuthorization();

        return group;
    }
}