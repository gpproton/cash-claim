using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using XClaim.Web.Client;
using XClaim.Web.Components.Extensions;
using XClaim.Web.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();
builder.Services.RegisterSharedBlazorServices();
builder.Services.RegisterServerRazorExtensions();
builder.Services.RegisterBlazorClientState();

await builder.Build().RunAsync();
