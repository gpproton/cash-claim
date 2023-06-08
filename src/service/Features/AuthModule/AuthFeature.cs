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
using Axolotl.AspNet.Feature;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.MicrosoftAccount;
using Microsoft.AspNetCore.Mvc;
using Nextended.Core.Extensions;

namespace XClaim.Service.Features.AuthModule;

public class AuthFeature : IFeature {
    public IServiceCollection RegisterModule(IServiceCollection services) {

        return services;
    }

    public IEndpointRouteBuilder MapEndpoints(IEndpointRouteBuilder endpoints) {
        const string name = "Authentication";
        const string url = $"/auth";
        var group = endpoints.MapGroup(url).WithTags(name);

        group.MapGet("/sign-in", ([FromQuery] string? redirect) => {
                var redirectUri = Environment.GetEnvironmentVariable("ROOT_URI") ?? (redirect.IsNullOrEmpty() ? Constants.RootApi : redirect);
                var props = new AuthenticationProperties {
                    IsPersistent = true,
                    RedirectUri = redirectUri
                };

                return Results.Challenge(props, new[] { MicrosoftAccountDefaults.AuthenticationScheme });
            }).WithName("SignIn")
            .WithOpenApi();

        group.MapGet("/sign-in/mobile", async (HttpRequest request, [FromQuery] string? scheme) => {
            var schemeValue = scheme.IsNullOrEmpty() ? "Microsoft" : scheme;
            var auth = await request.HttpContext.AuthenticateAsync(schemeValue);
            const string callbackScheme = "xclaim";

            if (!auth.Succeeded
                || auth?.Principal == null
                || !auth.Principal.Identities.Any(id => id.IsAuthenticated)
                || string.IsNullOrEmpty(auth.Properties.GetTokenValue("access_token"))) {
                await request.HttpContext.ChallengeAsync(schemeValue);
            }
            else {
                var claims = auth.Principal.Identities.FirstOrDefault()?.Claims;
                string? address = claims?.FirstOrDefault(c => c.Type == System.Security.Claims.ClaimTypes.Email)?.Value;
                if (address != null) {
                    string? emailAddress = address;
                    var qs = new Dictionary<string, string?> {
                        { "access_token", auth.Properties.GetTokenValue("access_token") },
                        { "refresh_token", auth.Properties.GetTokenValue("refresh_token") ?? string.Empty },
                        { "expires_in", (auth.Properties.ExpiresUtc?.ToUnixTimeSeconds() ?? -1).ToString() },
                        { "email", emailAddress }
                    };

                    var redirectUrl = callbackScheme + "://#" + string.Join(
                        "&",
                        qs.Where(kvp => !string.IsNullOrEmpty(kvp.Value) && kvp.Value != "-1")
                            .Select(kvp => $"{WebUtility.UrlEncode(kvp.Key)}={WebUtility.UrlEncode(kvp.Value)}"));

                    request.HttpContext.Response.Redirect(redirectUrl);
                }
            }}).WithName("MobileSignIn").WithOpenApi();

        group.MapPost("/sign-out", async (HttpRequest request) => {
            await request.HttpContext.SignOutAsync();
            return Results.Ok(true);
        }).WithName("SignOut")
            .WithOpenApi();

        return group;
    }
}