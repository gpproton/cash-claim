// Copyright 2023 - 2023 Godwin peter .O (me@godwin.dev)
//
// Licensed under the MIT License;
// you may not use this file except in compliance with the License.
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using XClaim.Common.Context;
using XClaim.Common.Entity;

namespace XClaim.Service.Extensions;

public static class AuthenticationExtensions {
    public static IServiceCollection RegisterAuthenticationService(this IServiceCollection services) {
        ServiceProvider sp = services.BuildServiceProvider();
        IConfiguration config = sp.GetRequiredService<IConfiguration>();
        // TODO: Re-create as IdentityProvider
        // services.AddTransient<IdentityHelper>();

        services.AddAuthentication(IdentityConstants.ApplicationScheme)
        .AddMicrosoftAccount(opt => {
            opt.SignInScheme = "Cookies";
            opt.ClientId = config.GetValue<string>("Microsoft:ClientId") ?? "client-id";
            opt.ClientSecret = config.GetValue<string>("Microsoft:ClientSecret") ?? "client-secret";
            opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            opt.SaveTokens = true;
        }).AddIdentityCookies();
        services.RegisterEntityIdentity();

        services.Configure<IdentityOptions>(options => {
            options.SignIn.RequireConfirmedEmail = false;
            options.Password.RequireDigit = true;
            options.Password.RequireLowercase = true;
            options.Password.RequireNonAlphanumeric = true;
            options.Password.RequireUppercase = true;
            options.Password.RequiredLength = 6;
            options.Password.RequiredUniqueChars = 1;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 5;
            options.Lockout.AllowedForNewUsers = true;
        });

        services.AddHttpContextAccessor();
        services.AddAuthorization();
        services.AddDistributedMemoryCache();

        return services;
    }
}