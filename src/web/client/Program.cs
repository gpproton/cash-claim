using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using XClaim.Web.Components;
using XClaim.Web.Components.Extensions;
using XClaim.Web.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<ClientApp>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.RegisterSharedBlazorServices();
builder.Services.RegisterComponentsExtensions();
builder.Services.RegisterBlazorClientState();

await builder.Build().RunAsync();
