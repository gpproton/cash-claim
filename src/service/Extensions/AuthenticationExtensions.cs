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

namespace XClaim.Service.Extensions {
    public static class AuthenticationExtensions {
        public static IServiceCollection RegisterAuthenticationService(this IServiceCollection services) {
            ServiceProvider? sp = services.BuildServiceProvider();
            IConfiguration? config = sp.GetRequiredService<IConfiguration>();

            // TODO: Re-create as IdentityProvider
            // services.AddTransient<IdentityHelper>();

            services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = _ => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication("Cookies")
                .AddCookie(opt => {
                    opt.Cookie.Name = Constants.AppSessionName;
                    opt.Cookie.IsEssential = true;
                    opt.ExpireTimeSpan = TimeSpan.FromDays(7);
                    opt.SlidingExpiration = true;
                })
                .AddMicrosoftAccount(opt => {
                    opt.SignInScheme = "Cookies";
                    opt.ClientId = config.GetValue<string>("Microsoft:ClientId") ?? "client-id";
                    opt.ClientSecret = config.GetValue<string>("Microsoft:ClientSecret") ?? "client-secret";
                    opt.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                    opt.SaveTokens = true;
                });

            services.AddHttpContextAccessor();
            ;
            services.AddAuthorization();
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromMinutes(2);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });

            return services;
        }
    }
}